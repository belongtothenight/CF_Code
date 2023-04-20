import os
import math
import csv
from LSystem import LSystem

'''
1. ghostscript error: https://stackoverflow.com/questions/44587376/oserror-unable-to-locate-ghostscript-on-paths
2. turtle export img: https://python-forum.io/thread-25822.html
'''


def calLSystem(
        w='',
        angleInt=90,  # Initial angle
        angleInc=0,  # Angle increment
        distance=0,  # Distance between each point
        # precision=4,
        centeringCo=False,  # Centering coordinates
        exportStatPath=None,  # Export max coordinates
        exportCoPath=None,  # Export coordinates
        exportDListPath=None  # Export dList (jump without drawing)
):
    w = [*w]
    maxLength = len(w)
    coordinates = [[0, 0, 0]]
    dList = []
    for i in range(len(w)):
        print(
            f'Drawing {i+1} / {maxLength} {(i+1)/maxLength*100:.2f}% ...', end='\r')
        if (w[i] == 'F'):
            x = coordinates[-1][0] + distance * \
                math.cos(math.radians(angleInt))
            z = coordinates[-1][2] + distance * \
                math.sin(math.radians(angleInt))
            coordinates.append(
                [
                    x,
                    0,
                    z,
                ]
            )
        elif (w[i] == '+'):
            angleInt += angleInc
        elif (w[i] == '-'):
            angleInt -= angleInc
        elif (w[i] == 'd'):
            x = coordinates[-1][0] + distance * \
                math.cos(math.radians(angleInt))
            z = coordinates[-1][2] + distance * \
                math.sin(math.radians(angleInt))
            coordinates.append(
                [
                    x,
                    0,
                    z,
                ]
            )
            dList.append(i)
    if centeringCo:
        xMin = min([x[0] for x in coordinates])
        xMax = max([x[0] for x in coordinates])
        zMin = min([x[2] for x in coordinates])
        zMax = max([x[2] for x in coordinates])
        xCenter = (xMax + xMin) / 2
        zCenter = (zMax + zMin) / 2
        for i in range(len(coordinates)):
            coordinates[i][0] -= xCenter
            coordinates[i][2] -= zCenter
        if exportStatPath is not None:
            with open(exportStatPath, 'w', newline='') as csvfile:
                writer = csv.writer(csvfile)
                writer.writerow(
                    ['xMin', 'xMax', 'zMin', 'zMax', 'width', 'height'])
                writer.writerow(
                    [xMin, xMax, zMin, zMax, xMax - xMin, zMax - zMin])
    if exportCoPath is not None:
        with open(exportCoPath, 'w', newline='') as csvfile:
            writer = csv.writer(csvfile)
            writer.writerow(['x', 'y', 'z'])
            for i in range(len(coordinates)):
                writer.writerow(coordinates[i])
    if exportDListPath is not None:
        with open(exportDListPath, 'w', newline='') as csvfile:
            writer = csv.writer(csvfile)
            # writer.writerow(['dList'])
            # for i in range(len(dList)):
            #     writer.writerow([dList[i]])
            writer.writerow(dList)
    print('\nDrawing done.\n')


if __name__ == '__main__':
    # os.system('cls')
    maxLevel = 3
    segmentLength = 10

    # Q0
    print('Processing Q0')
    w = LSystem(
        w='F',
        level=maxLevel,
        newf='F-F++F-F',
        newb=''
    )
    calLSystem(
        w=w,
        angleInt=0,
        angleInc=60,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q0_stat.csv',
        exportCoPath='Q0_co.csv',
        exportDListPath='Q0_dList.csv'
    )

    # Q1 (2)
    print('Processing Q1')
    w = LSystem(
        w='F+F+F+F',
        level=maxLevel,
        newf='F+F-F-FFF+F-F',
        newb=''
    )
    calLSystem(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q1_stat.csv',
        exportCoPath='Q1_co.csv',
        exportDListPath='Q1_dList.csv'
    )

    # Q2 (3)
    print('Processing Q2')
    w = LSystem(
        w='F++F++F',
        level=maxLevel,
        newf='F-F++F-F',
        newb=''
    )
    calLSystem(
        w=w,
        angleInt=0,
        angleInc=60,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q2_stat.csv',
        exportCoPath='Q2_co.csv',
        exportDListPath='Q2_dList.csv'
    )

    # Q3
    print('Processing Q3')
    w = LSystem(
        w='F',
        level=maxLevel,
        newf='F-F+F+F+F-F-F-F+F',
        newb=''
    )
    calLSystem(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q3_stat.csv',
        exportCoPath='Q3_co.csv',
        exportDListPath='Q3_dList.csv'
    )

    # Q4 (1)
    print('Processing Q4')
    w = LSystem(
        w='F+F+F+F',
        level=maxLevel,
        newf='F+b-F-FFF+F+b-F',
        newb='bbb'
    )
    calLSystem(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q4_stat.csv',
        exportCoPath='Q4_co.csv',
        exportDListPath='Q4_dList.csv'
    )

    # Q5 (4)
    print('Processing Q5')
    w = LSystem(
        w='F-F-F-F',
        level=maxLevel,
        newf='F-b+F-F-F-Fb-F+b-F+F+F+Fb+FF',
        newb='bbbb'
    )
    calLSystem(
        w=w,
        angleInt=0,
        angleInc=90,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q5_stat.csv',
        exportCoPath='Q5_co.csv',
        exportDListPath='Q5_dList.csv'
    )

    # Q6 (5)
    print('Processing Q6')
    w = LSystem(
        w='F',
        level=maxLevel,
        newf='F-F+F+F+F-F-F-F+F',
        newb=''
    )
    calLSystem(
        w=w,
        angleInt=45,
        angleInc=90,
        distance=segmentLength,
        centeringCo=True,
        exportStatPath='Q6_stat.csv',
        exportCoPath='Q6_co.csv',
        exportDListPath='Q6_dList.csv'
    )
