import json , requests
from flask import Flask, request
import xml.etree.ElementTree as ET

app = Flask("server")

@app.route("/get_my_ip", methods=["GET"])
def get_my_ip():
    #return jsonify({'ip': request.remote_addr}), 200
    return "ip " + request.remote_addr
#########################################################################################
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
            #status()
        else :
            self.ultimo.prox = nodo
            self.ultimo = nodo
            #status()
       
    def imprimir(self):
        aux = self.primero
        while aux != None:
            print "Nodo insertado :"+ str(aux.ip)
            aux = aux.prox 

def jsonDefault(object):
    return object.__dict__

def status(aux = None):
    aux = listaIp.primero
    if aux != None :
        r = requests.get("http://"+ aux.ip +":5000/conectado")
        if r.status_code == 200:
            return r.text        

listaIp = ListaEnlazada()
@app.route('/metodoPost',methods=['POST']) 
def metodoPost():
    parametro = str(request.form['var1'])
    parametro2 = str(request.form['var2'])
    return parametro + parametro2
    

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
        r = requests.get("http://"+ clave3["ip"] +":5000/conectado")
        if r.status_code == 200:
            carnet = r.text         
        listaIp.insertar(Nodo(clave3["ip"], carnet))
        #response = response + str(clave3["ip"])
        #print "El valor de IP es %s y Mascara es %s " % (clave3["ip"],clave3["mascara"])

    return json.dumps(listaIp, default = jsonDefault)
    #return listaIp.status(Nodo(clave3["ip"], clave3["mascara"]))
    #return listaIp.status()
    #return "successful"

@app.route('/conectado',methods=['GET'])
def conectado():
    return "201212919"

@app.route('/getStatus',methods=['POST'])
def status():
    r = requests.get("http://"+ request.data +":5000/conectado")
    if r.status_code == 200:
        return r.text        

######################################################################
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

    def queue(self, nodoCola = None):
        if self.primero == None :
            self.primero = nodoCola
            self.ultimo = nodoCola
        else :
            self.ultimo.prox = nodoCola
            self.ultimo = nodoCola
    def dequeue(self):
        aux = self.primero
        self.primero = aux.prox
        return str(aux.operacion) 
       
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
    parametroPython = str(request.data)
    #print parametroPython    
    colaMensajes.queue(NodoCola(request.data))
    #colaMensajes.imprimir()
    return "true"

@app.route('/operar', methods = ['GET'])
def operar():
    pilaNumero = Pila()
    pilaOperador = Pila()
    resultado = ""
    postorden = ""
    for x in request.data:
        if x in (' ', '('):
            print ""
        elif x == ")": 
            var1 = pilaNumero.pop()
            var2 = pilaNumero.pop()
            op = pilaOperador.pop() 
            var3 = None
            postorden = postorden + str(op)           
            if op == "+":
               var3 = int(var1) + int(var2)
               print var3
            elif op == "-":
               var3 = int(var2) - int(var1)
               print var3
            elif op == "*":
               var3 = int(var1) * int(var2)
               print var3
            elif op == "/":
               var3 = int(var1) / int(var2)               
               print var3
            pilaNumero.push(var3)
        elif x  in ('/', '*', '-', '+'):
            pilaOperador.push(x)
        else:
            pilaNumero.push(x)
            postorden = postorden + str(x) 
            print x  

    resultado = pilaNumero.pop()
    return "true" + str(resultado)+ "POST"+ str(postorden)
    #r = requests.post("http://192.168.10.101:5000/respuesta", data = resultado , postorden)
    #if r.status_code == 200:
    #    return r.text    
   
@app.route('/respuesta',methods=['POST']) 
def respuesta():
    textoenviar = str(request.data)
    ipRecup = str(request.environ['REMOTE_ADDR'])
    #print (str(textoenviar))
    return "Repuesta de Estrellita " + textoenviar + ipRecup


#######################################################################
@app.route('/hola') 
def he():
    return "hola Mundo"

if __name__ == "__main__":
    #app.run(debug=True, host='192.168.10.104')
    app.run(debug=True, host='192.168.1.5')