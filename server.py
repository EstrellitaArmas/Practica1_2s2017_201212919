import json , requests
from flask import Flask, request
import xml.etree.ElementTree as ET

app = Flask("server")

@app.route("/get_my_ip", methods=["GET"])
def get_my_ip():
    #return jsonify({'ip': request.remote_addr}), 200
    return "ip " + request.remote_addr
##########################################DASHBOARD###################
class Nodo(object):
    def __init__(self, ip=None,carnet= None, prox = None):
        self.ip = ip
        self.carnet = carnet 
        self.prox = prox
    def __str__(self):
        return str(self.ip, self.mascara)

class ListaEnlazada(object):
    def __init__(self):
        self.primero = None
        self.ultimo = None

    def insertar(self, nodo = None):
        if self.primero == None :
            self.primero = nodo
            self.ultimo = nodo
        else :
            self.ultimo.prox = nodo
            self.ultimo = nodo
       
    def imprimir(self):
        aux = self.primero
        while aux != None:
            print "Nodo insertado :"+ str(aux.ip)
            aux = aux.prox   
    def modificar(self, ip = None , carnet = None):
            aux = self.primero
            while aux != None:
                if aux.ip == ip:
                    aux.carnet = carnet
                aux = aux.prox   

@app.route('/metodoPost',methods=['POST']) 
def metodoPost():
    parametro = str(request.form['var1'])
    parametro2 = str(request.form['var2'])
    return parametro + parametro2
    
def jsonDefault(object):
    return object.__dict__

listaIp = ListaEnlazada()
@app.route('/cargaJSON',methods=['POST']) 
def cargaJSON():
    nodos = (request.json)
    for clave, valor in nodos.iteritems():
        for clave2, valor2 in valor.iteritems():
            if clave2 == "nodo":
                nodo = valor2
            else:
                print ": %s es %s:" % (clave2, valor2)                
            
    for clave3 in nodo:
        try:
            r = requests.get("http://"+ clave3["ip"] +":5000/conectado")
            if r.status_code == 200:
                listaIp.insertar(Nodo(clave3["ip"], r.text))
        except requests.exceptions.RequestException as e:
            listaIp.insertar(Nodo(clave3["ip"], "-"))
            print e
        #print "El valor de IP es %s y Mascara es %s " % (clave3["ip"],clave3["mascara"])

    return json.dumps(listaIp, default = jsonDefault )

@app.route('/conectado',methods=['GET'])
def conectado():
    return "201212919"

@app.route('/getStatus',methods=['GET'])
def status():
    aux = listaIp.primero
    while aux != None:
        try:
            r = requests.get("http://"+ aux.ip +":5000/conectado")
            if r.status_code == 200:
                listaIp.modificar(aux.ip,r.text)
        except requests.exceptions.RequestException as e : 
            listaIp.modificar(aux.ip, "-")
            print e
        aux = aux.prox  

    
    return json.dumps(listaIp, default = jsonDefault)

##############################################MENSAJES################
class NodoCola(object):
    def __init__(self, operacion =None, ip = None, prox = None):
        self.ip = ip
        self.operacion = operacion 
        self.prox = prox
    def __str__(self):
        return str(self.ip, self.mascara)

class ColaMensajes(object):
    def __init__(self):
        self.primero = None
        self.ultimo = None
        self.tamanio = 0
        
    def queue(self, nodoCola = None):
        if self.primero == None :
            self.primero = nodoCola
            self.ultimo = nodoCola
        else :
            self.ultimo.prox = nodoCola
            self.ultimo = nodoCola
        self.tamanio +=1

    def dequeue(self):
        if self.primero != None:
            temp = self.primero
            self.primero = temp.prox 
            nodo = {'operacion': temp.operacion ,'ip':temp.ip }
            self.tamanio -=1
            return nodo 
       
    def imprimir(self):
        aux = self.primero
        while aux != None:
            print "Nodo insertado :"+ str(aux.operacion)
            aux = aux.prox 

class NodoPila(object):
    def __init__(self, dato=None, siguiente = None):
        self.dato = dato
        self.siguiente = siguiente
    def __str__(self):
        return str(self.dato)

class Pila(object):
    def __init__(self):
        self.ultimo = None 

    def push(self, dato):
        if self.ultimo != None:
            temp = self.ultimo
            self.ultimo = NodoPila(dato)
            self.ultimo.siguiente = temp
        else:
            self.ultimo = NodoPila(dato)
            
    def pop(self):
        if self.ultimo != None:
            temp = self.ultimo
            self.ultimo = temp.siguiente
            return temp.dato
        
    def mostrarPila(self):
        if self.ultimo != None:
            temp = self.ultimo
            print ("\nLos datos de la pila son: ")
            while temp != None:
                print (str(temp.dato))
                temp = temp.siguiente 
                
colaMensajes = ColaMensajes()
@app.route('/cntCola',methods = ['GET'])
def cntCola():
    tamanio = str(colaMensajes.tamanio)
    return tamanio
@app.route('/cargaXML', methods=['POST'])
def cargaXML():
    textoEnviar = ""
    #mensajes = ET.ElementTree( file = 'mensaje.xml')
    mensajes = ET.parse(request.data , parser = None)
    root = mensajes.getroot()
    for mensaje in mensajes.iterfind('mensaje'):
        for ip in mensaje.iterfind('IP'):
            r = requests.post("http://"+ ip.text +":5000/mensaje", data = textoEnviar )
            #print ip.tag, ip.text 
        for texto in mensaje.iterfind('texto'):
            textoEnviar = texto.text
            #print texto.tag, texto.text

        for nodo in mensaje.iterfind('nodos'):
            for ip in nodo.iterfind('IP'):
                r = requests.post("http://"+ ip.text +":5000/mensaje", data = textoEnviar)
                #print nodo.tag, ip.text 
    
    return "successful"


@app.route('/mensaje', methods =['POST'])
def mensaje():
    #parametroPython = str(request.data)    
    ipRecup = str(request.environ['REMOTE_ADDR'])
    #colaMensajes.queue(NodoCola(request.data,ipRecup))
    colaMensajes.queue(NodoCola(request.form["inorden"],ipRecup))
    colaMensajes.imprimir()
    #print ipRecup
    return "true"

@app.route('/operar', methods = ['GET'])
def operar():
    pilaNumero = Pila()
    pilaOperador = Pila()
    resultado = ""
    postorden = ""
    numero = ""
    colaEjecucion = ""
    nodo = colaMensajes.dequeue()
    print nodo
    if nodo != None:
        operacion = nodo["operacion"]
        ipRecup = nodo["ip"]
        for x in str(operacion):
            print x
            if x in (' ', '('):
                print ""
            elif x == ")": 
                if numero != "":
                    pilaNumero.push(numero)
                    colaEjecucion += "push(" + numero +")\n"
                    postorden = postorden  + numero + " "
                    numero=""
               
                var1 = pilaNumero.pop()
                var2 = pilaNumero.pop()
                op = pilaOperador.pop()
                colaEjecucion += "pop()\npop()\n"
                postorden = postorden + str(op) + " "                          
                if op == "+":
                    var3 = int(var1) + int(var2)
                    pilaNumero.push(var3)
                    colaEjecucion += str(var1)+"+"+str(var2) + "=" + str(var3) + "\npush(" + str(var3) +")\n"
                    #print var3
                elif op == "-":
                    var3 = int(var2) - int(var1)
                    pilaNumero.push(var3)
                    colaEjecucion += str(var2)+"-"+str(var1) + "=" + str(var3) + "\npush(" + str(var3) +")\n"
                    #print var3
                elif op == "*":
                    var3 = int(var1) * int(var2)
                    pilaNumero.push(var3)
                    colaEjecucion += str(var1)+"*"+str(var2) + "=" + str(var3) + "\npush(" + str(var3) +")\n"
                    #print var3
                elif op == "/":
                    var3 = int(var2) / int(var1)               
                    pilaNumero.push(var3)
                    colaEjecucion += str(var2)+"/"+str(var1) + "=" + str(var3) + "\npush(" + str(var3) +")\n"
                    #print var3
                
            elif x  in ('/', '*', '-', '+'):
                pilaOperador.push(x)                
                if numero != "" :
                    postorden = postorden  + numero + " "
                    pilaNumero.push(numero)
                    colaEjecucion += "push(" + numero +")\n"
                    numero=""
            else:
                #pilaNumero.push(x)
                numero = numero + x                
                #postorden = postorden + " " + str(x) 

        resultado = pilaNumero.pop()
        nodo = {'resultado': resultado ,'postorden': postorden , 'inorden' : operacion , 'carnet':'201212919'}
        #return "true de prueba" + str(resultado)+ "POST"+ str(postorden)
        try:
            r = requests.post("http://"+ipRecup+":5000/respuesta", data = nodo)
            #r = requests.post("http://192.168.1.5:5000/respuesta", data = nodo)
            if r.status_code == 200:
                respuestaLocal = {'resultado': resultado ,'postorden': postorden , 'inorden' : operacion ,'ipRecup': ipRecup , 'enviado' : "true" , 'colaEjecucion': colaEjecucion}
                return json.dumps(respuestaLocal, default = jsonDefault)
        except requests.exceptions.RequestException as e : 
            print e    
            return "No se pudo enviar el resultado"            
    else:
        return "la cola esta vacia"
   
   
###################################RESPUESTAS##########################
class NodoDoble(object):
    def __init__(self, ip = None , inorden= None,postorden= None, resultado= None, prox = None , ant = None):
        self.inorden = inorden 
        self.postorden = postorden 
        self.resultado = resultado
        self.ip = ip 
        self.prox = prox
        self.ant = ant
    def __str__(self):
        return str(self.inorden, self.postorden , self.resultado)

class ListaDobleEnlazada(object):
    def __init__(self):
        self.primero = None
        self.ultimo = None

    def insertar(self, nodo = None):
        if self.primero == None :
            self.primero = nodo
            self.ultimo = nodo
        else :
            nodo.prox = self.primero
            self.primero.ant = nodo 
            self.primero = nodo
       
    def imprimir(self):
        aux = self.primero
        while aux != None:
            print "Nodo insertado :"+ str(aux.resultado)
            aux = aux.prox  
        print "fin de la lista"
            
listaRespuestas = ListaDobleEnlazada()
@app.route('/respuesta',methods=['POST']) 
def respuesta():
    #textoenviar = str(request.data)
    ipRecup = str(request.environ['REMOTE_ADDR'])
    listaRespuestas.insertar(NodoDoble(ipRecup,request.form['inorden'], request.form['postorden'], request.form['resultado']))
    listaRespuestas.imprimir()
    #print (str(textoenviar))
    #return "Repuesta de Estrellita " + textoenviar + ipRecup
    return "true"

@app.route('/getRespuestas',methods=['GET'])
def getRespuestas():
    contador = 0
    listaRespuestasDTO = dict()
    aux = listaRespuestas.primero
    while aux != None:
        contador +=1
        respuestaLocal = {'resultado': str(aux.resultado) ,'postorden':str(aux.postorden), 'inorden': str(aux.inorden),'ipRecup': str(aux.ip)}
        listaRespuestasDTO['respuesta'+ str(contador)] = respuestaLocal
        print "Nodo insertado :"+ str(aux.resultado)
        aux = aux.prox  

    return json.dumps(listaRespuestasDTO, default = jsonDefault)
    
#################################################################################################
   
@app.route('/hola')
def he():
    return "hola Mundo"

if __name__ == "__main__":
   # app.run(debug=True, host='192.168.10.102')
    app.run(debug=True, host='192.168.1.3')