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
        angleInt=90,
        angleInc=60,
        distance=0,
        exportPath=None,
        width=1920,
        height=1080,
        xOffset=0,
        yOffset=0,
        scale=2):
    from turtle import Screen, Turtle
    import turtle
    w = [*w]
    width = width*(1+0.1*scale)
    height = height*(1+0.1*scale)
    maxLength = len(w)
    t = Turtle()
    screen = Screen()
    screen.setup(width=width, height=height)
    screen.setworldcoordinates(-1, -1, screen.window_width() -
                               1, screen.window_height() - 1)
    # t.pencolor('white')
    t.speed(9)
    t.pensize(1*scale)
    t.hideturtle()
    t.penup()
    t.goto(xOffset, yOffset)
    t.pendown()
    t.left(angleInt)
    for i in range(len(w)):
        print(
            f'Drawing {i+1} / {maxLength} {(i+1)/maxLength*100:.2f}% ...', end='\r')
        if (w[i] == 'F'):
            t.forward(distance)
        elif (w[i] == '+'):
            t.left(angleInc)
        elif (w[i] == '-'):
            t.right(angleInc)
        elif (w[i] == 'b'):
            t.penup()
            t.forward(distance)
            t.pendown()
    if exportPath != None:
        canvas = t.screen.getcanvas()
        canvas.postscript(file=exportPath, width=width, height=height)
        img = Image.open(exportPath)
        img.save(exportPath[:-4]+'.png')
    turtle.bye()
    print('\nDrawing done.\n')


class EXECUTOR():
    def singleRun(w, angleInt, angleInc, distance, exportPath, width, height, xOffset, yOffset, scale):
        p = mp.Process(target=drawLSystem, args=(
            w, angleInt, angleInc, distance, exportPath, width, height, xOffset, yOffset, scale))
        p.start()
        p.join()


if __name__ == '__main__':
    # os.system('cls')
    maxLevel = 1
    distance = 10
    scale = 2
    # turtle.bgcolor('black')

    # Q0
    print('Processing Q0')
    w = LSystem(
        w='F',
        level=maxLevel,
        newf='F-F++F-F',
        newb=''
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=0,
        angleInc=60,
        distance=distance,
        exportPath='Q0.eps',
        width=300,
        height=100,
        xOffset=0,
        yOffset=0,
        scale=scale
    )

    # Q1 (2)
    print('Processing Q1')
    w = LSystem(
        w='F+F+F+F',
        level=maxLevel,
        newf='F+F-F-FFF+F-F',
        newb=''
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=distance,
        exportPath='Q1.eps',
        width=400,
        height=450,
        xOffset=400,
        yOffset=100,
        scale=scale
    )

    # Q2 (3)
    print('Processing Q2')
    w = LSystem(
        w='F++F++F',
        level=maxLevel,
        newf='F-F++F-F',
        newb=''
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=0,
        angleInc=60,
        distance=distance,
        exportPath='Q2.eps',
        width=300,
        height=350,
        xOffset=50,
        yOffset=250,
        scale=scale
    )

    # Q3
    print('Processing Q3')
    w = LSystem(
        w='F',
        level=maxLevel,
        newf='F-F+F+F+F-F-F-F+F',
        newb=''
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=distance,
        exportPath='Q3.eps',
        width=300,
        height=300,
        xOffset=50,
        yOffset=150,
        scale=scale
    )

    # Q4 (1)
    print('Processing Q4')
    w = LSystem(
        w='F+F+F+F',
        level=maxLevel,
        newf='F+b-F-FFF+F+b-F',
        newb='bbb'
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=distance,
        exportPath='Q4.eps',
        width=1000,
        height=1000,
        xOffset=200,
        yOffset=300,
        scale=scale
    )

    # Q5 (4)
    print('Processing Q5')
    w = LSystem(
        w='F-F-F-F',
        level=maxLevel,
        newf='F-b+F-F-F-Fb-F+b-F+F+F+Fb+FF',
        newb='bbbb'
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=distance,
        exportPath='Q5.eps',
        width=1300,
        height=1300,
        xOffset=500,
        yOffset=-50,
        scale=scale
    )

    # Q6 (5)
    print('Processing Q6')
    w = LSystem(
        w='F',
        level=maxLevel,
        newf='F-F+F+F+F-F-F-F+F',
        newb=''
    )
    EXECUTOR.singleRun(
        w=w,
        angleInt=45,
        angleInc=90,
        distance=distance,
        exportPath='Q6.eps',
        width=300,
        height=300,
        xOffset=50,
        yOffset=150,
        scale=scale
    )
