import os


def LSystem(w='', level=0, newf='', newb=''):
    w = [*w]
    newf = [*newf]
    newb = [*newb]
    maxLevel = level
    T = []
    n = len(w)

    while level > 0:
        print(
            f'Processing level {maxLevel-level+1} / {maxLevel} ...', end='\r')
        for i in range(n):
            if (w[i] == '+'):
                T.append('+')
            elif (w[i] == '-'):
                T.append('-')
            elif (w[i] == 'F'):
                T += (newf)
            elif (w[i] == 'b'):
                T += (newb)
        w = T
        T = []
        level -= 1
        n = len(w)

    w = ''.join(w)
    # print(w)
    print('\nProcessing done.')
    return w


def exportTxt(q=0, W='', level=0, newf='', newb='', w=''):
    f = open('Q'+str(q)+'.txt', 'w', encoding='utf-8')
    f.write('W = '+W+'\n')
    f.write('level = '+str(level)+'\n')
    f.write('newf = '+newf+'\n')
    f.write('newb = '+newb+'\n')
    f.write('w = '+w+'\n')
    f.close()


if __name__ == '__main__':
    os.system('cls')
    # Q0
    W = 'F'
    level = 2
    newf = 'F-F++F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    exportTxt(0, W, level, newf, newb, w)
    print()

    # Q1
    W = 'F+F+F+F'
    level = 2
    newf = 'F+F-F-FFF+F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    exportTxt(1, W, level, newf, newb, w)
    print()

    # Q2
    W = 'F++F++F'
    level = 3
    newf = 'F-F++F-F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    exportTxt(2, W, level, newf, newb, w)
    print()

    # Q3
    W = 'F'
    level = 3
    newf = 'F-F+F+F+F-F-F-F+F'
    newb = ''
    w = LSystem(W, level, newf, newb)
    exportTxt(3, W, level, newf, newb, w)
