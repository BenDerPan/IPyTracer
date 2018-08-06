import os
import sys

#引入IPyTracer库路径
sys.path.append("..\..\..\..")

from IPyTracer.core.model import ModelObject
class Man:
    def __init__(self, name,age):
        self.name=name
        self.age=age
        self.obj=None

    def Add(self,a,b):
        self.obj=ModelObject(self)
        return a+b

    def Say(self,message):
        print("听我说：",message)

    def Run(self):
        print("我正在运行")


def Ping(target):
    print("正在执行ping：",target)
    m=Man("大娜迦",100)
    v=m.Add(123,456)
    print(v)
    return "结果：{0} {1}".format(target,v)

if __name__ =="__main__":
    Ping("1.2.3.4")