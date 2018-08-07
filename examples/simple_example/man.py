# coding:utf-8
import os
import sys

#引入IPyTracer库路径
sys.path.append("..\..\..\..")

from IPyTracer import Tracer
ipyTracer=Tracer()
class Man:
   
    def __init__(self, name,age):
        self.name=name
        self.age=age
        self.childs=[]

    def Add(self,a,b):
        global ipyTracer
        ipyTracer.Watch("Man.Add",self)
        child=Man("小明",5)
        self.childs.append(child)
        return a+b

    def Say(self,message):
        print("听我说：",message)

    def Run(self):
        print("我正在运行")

def Run():
    global ipyTracer
    a=100
    b=200
    c=0
    ipyTracer.Watch("a",a)
    ipyTracer.Watch("b",b)
    ipyTracer.Watch("c",c)

    c=a*b+a
    ipyTracer.Watch("c2",c)

    m=Man("Jack",19)
    m.Add(a,b)
    m.Say("Hello")
    m.Run()