import os
import multiprocess as mp
from PIL import Image
from LSystem import LSystem

'''
1. ghostscript error: https://stackoverflow.com/questions/44587376/oserror-unable-to-locate-ghostscript-on-paths
2. turtle export img: https://python-forum.io/thread-25822.html
'''


def drawLSystem(
        w='',
        angle=0,
        distance=0,
        exportPath=None,
        width=1920,
        height=1080,
        xOffset=0,
        yOffset=0):
    import turtle
    import tkinter
    w = [*w]
    maxLength = len(w)
    t = turtle.Turtle()
    turtle.setup(width, height)
    drawing_width = turtle.window_width()
    drawing_height = turtle.window_height()
    turtle.screensize(drawing_width, drawing_height)
    # t.screen.screensize(width, height)
    # t.pencolor('white')
    t.speed(0)
    t.pensize(2)
    t.hideturtle()
    t.penup()
    t.goto(xOffset, yOffset)
    t.pendown()
    for i in range(len(w)):
        print(
            f'Drawing {i+1} / {maxLength} {(i+1)/maxLength*100:.2f}% ...', end='\r')
        if (w[i] == 'F'):
            t.forward(distance)
        elif (w[i] == '+'):
            t.right(angle)
        elif (w[i] == '-'):
            t.left(angle)
        elif (w[i] == 'd'):
            t.penup()
            t.forward(distance)
            t.pendown()
    if exportPath != None:
        canvas = t.screen.getcanvas()
        canvas.postscript(file=exportPath, width=width, height=height)
        img = Image.open(exportPath)
        img.save(exportPath[:-4]+'.png')
    # turtle.done()
    turtle.bye()
    print('\nDrawing done.\n')


class EXECUTOR():
    def singleRun(w, angle, distance, exportPath, width, height, xOffset, yOffset):
        p = mp.Process(target=drawLSystem, args=(
            w, angle, distance, exportPath, width, height, xOffset, yOffset))
        p.start()
        p.join()


if __name__ == '__main__':
    os.system('cls')
    maxLevel = 5
    # turtle.bgcolor('black')

    # Q0
    print('Processing Q0')
    exportPath = 'Q0.eps'
    W = 'F'
    level = maxLevel
    newf = 'F-F++F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = 1920*2
    height = 1080*2
    xOffset = 0
    yOffset = height*(-0.5)
    # drawLSystem(w, 60, 10, exportPath, width, height, xOffset, yOffset)
    EXECUTOR.singleRun(w, 60, 10, exportPath, width, height, xOffset, yOffset)

    # Q1
    print('Processing Q1')
    exportPath = 'Q1.eps'
    W = 'F+F+F+F'
    level = maxLevel
    newf = 'F+F-F-FFF+F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = 1920*2
    height = 1080*2
    xOffset = 0
    yOffset = 0
    # drawLSystem(w, 90, 10, exportPath, width, height, xOffset, yOffset)
    EXECUTOR.singleRun(w, 90, 10, exportPath, width, height, xOffset, yOffset)

    # Q2
    print('Processing Q2')
    exportPath = 'Q2.eps'
    W = 'F++F++F'
    level = maxLevel
    newf = 'F-F++F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = int(1920*3)
    height = int(1080*3)
    xOffset = 0
    yOffset = -0.1*height
    # drawLSystem(w, 60, 10, exportPath, width, height, xOffset, yOffset)
    EXECUTOR.singleRun(w, 60, 10, exportPath, width, height, xOffset, yOffset)

    # Q3
    print('Processing Q3')
    exportPath = 'Q3.eps'
    W = 'F'
    level = maxLevel
    newf = 'F-F+F+F+F-F-F-F+F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = int(1920*3)
    height = int(1080*3)
    xOffset = 0
    yOffset = -0.3*height
    # drawLSystem(w, 90, 10, exportPath, width, height, xOffset, yOffset)
    EXECUTOR.singleRun(w, 90, 10, exportPath, width, height, xOffset, yOffset)
