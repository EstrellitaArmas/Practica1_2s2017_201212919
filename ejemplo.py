__author__ = "Mac"
__date__ = "$Ago 6, 2017 11:41:07 AM$"
import json
from flask import Flask, request

app = Flask("ejemplo_segundo_semestre_2017")

@app.route('/metodo2',methods=['POST']) 
def h():
    parametroPython = str(request.json)
    nodos = (request.json) 
    for clave, valor in nodos.iteritems():
        for clave2, valor2 in valor.iteritems():
            print "El valor de la clave %s es %s" % (clave2, valor2)
            for clave3, valor3 in valor2.iteritems():
                print "El valor de la clave %s es %s" % (clave3, valor3)

    return "parametro!! = " + parametroPython

class Nodo(object):
    def __init__(self, dato=None, prox = None):
        self.dato = dato
        self.prox = prox
    def __str__(self):
        return str(self.dato)


@app.route('/hola') 
def he():
    return "hola Mundo"

if __name__ == "__main__":
  app.run(debug=True, host='127.0.0.1')