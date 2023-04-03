import os
import math
import csv
from LSystem import LSystem

'''
1. ghostscript error: https://stackoverflow.com/questions/44587376/oserror-unable-to-locate-ghostscript-on-paths
2. turtle export img: https://python-forum.io/thread-25822.html
'''


def drawLSystem(
        w='',
        angle=0,
        distance=0,
        # precision=4,
        exportPath=None,):
    w = [*w]
    maxLength = len(w)
    coordinates = [[0, 0, 0]]
    currentAngle = 90
    for i in range(len(w)):
        print(
            f'Drawing {i+1} / {maxLength} {(i+1)/maxLength*100:.2f}% ...', end='\r')
        if (w[i] == 'F'):
            x = coordinates[-1][0] + distance * \
                math.sin(math.radians(currentAngle))
            z = coordinates[-1][2] + distance * \
                math.cos(math.radians(currentAngle))
            coordinates.append(
                [
                    x,
                    0,
                    z,
                ]
            )
        elif (w[i] == '+'):
            currentAngle += angle
        elif (w[i] == '-'):
            currentAngle -= angle
        elif (w[i] == 'd'):
            # coordinates.append(
            #     [
            #         coordinates[-1][0],
            #         0,
            #         coordinates[-1][2],
            #     ]
            # )
            pass
    with open(exportPath, 'w', newline='') as csvfile:
        writer = csv.writer(csvfile)
        writer.writerow(['x', 'y', 'z'])
        for i in range(len(coordinates)):
            writer.writerow(coordinates[i])
    print('\nDrawing done.\n')


if __name__ == '__main__':
    os.system('cls')
    maxLevel = 5
    segmentLength = 0.05

    # Q0
    print('Processing Q0')
    exportPath = 'Q0.csv'
    W = 'F'
    level = maxLevel
    newf = 'F-F++F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = 1920*2
    height = 1080*2
    xOffset = 0
    yOffset = height*(-0.5)
    drawLSystem(w, 60, segmentLength, exportPath)

    # Q1
    print('Processing Q1')
    exportPath = 'Q1.csv'
    W = 'F+F+F+F'
    level = maxLevel
    newf = 'F+F-F-FFF+F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = 1920*2
    height = 1080*2
    xOffset = 0
    yOffset = 0
    drawLSystem(w, 90, segmentLength, exportPath)

    # Q2
    print('Processing Q2')
    exportPath = 'Q2.csv'
    W = 'F++F++F'
    level = maxLevel
    newf = 'F-F++F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = 1920*2
    height = 1080*2
    xOffset = 0
    yOffset = 0
    drawLSystem(w, 60, segmentLength, exportPath)

    # Q3
    print('Processing Q3')
    exportPath = 'Q3.csv'
    W = 'F'
    level = maxLevel
    newf = 'F-F+F+F+F-F-F-F+F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    width = 1920*2
    height = 1080*2
    xOffset = 0
    yOffset = 0
    drawLSystem(w, 90, segmentLength, exportPath)
