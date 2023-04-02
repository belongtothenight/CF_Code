import os
os.system('cls')


def LSystem(W='', level=0, newf='', newb=''):
    W = [*W]
    newf = [*newf]
    newb = [*newb]
    T = []
    n = len(W)

    while level > 0:
        for i in range(n):
            if (W[i] == '+'):
                T.append('+')
            elif (W[i] == '-'):
                T.append('-')
            elif (W[i] == 'F'):
                T += (newf)
            elif (W[i] == 'b'):
                T += (newb)
        W = T
        T = []
        level -= 1
        n = len(W)

    w = ''.join(W)
    print(w)

    return w


def exportTxt(q=0, W='', level=0, newf='', newb='', w=''):
    f = open('Q'+str(q)+'.txt', 'w', encoding='utf-8')
    f.write('W = '+W+'\n')
    f.write('level = '+str(level)+'\n')
    f.write('newf = '+newf+'\n')
    f.write('newb = '+newb+'\n')
    f.write('w = '+w+'\n')
    f.close()


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
