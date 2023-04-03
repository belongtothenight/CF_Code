import matplotlib.pyplot as plt
import numpy as np
import os
import decimal


def normal(xInit1, xInit2, n):
    X1 = [xInit1]
    X2 = [xInit2]

    counter = 0

    while True:
        counter += 1
        X1.append(X1[-1]**2-2)
        X2.append(X2[-1]**2-2)
        if counter > n:
            break

    return X1, X2


def highPrecision(xInit1, xInit2, n, precision):
    decimal.getcontext().prec = precision  # set precision to 100
    X1 = [decimal.Decimal(xInit1)]
    X2 = [decimal.Decimal(xInit2)]
    param = decimal.Decimal(2)

    counter = 0

    while True:
        counter += 1
        X1.append(X1[-1]**param-param)
        X2.append(X2[-1]**param-param)
        if counter > n:
            break

    return X1, X2


if __name__ == "__main__":
    os.system('cls')

    n = 100
    # X1, X2 = normal(0.5, 0.55, n)
    X1, X2 = highPrecision(0.5, 0.55, n, 100)
    X1 = np.array(X1)
    X2 = np.array(X2)

    plt.plot(X1, label='$x(0) = 0.5$')
    plt.plot(X2, label='$x(0) = 0.55$')
    plt.plot(X1-X2, label='$\Delta x$')
    plt.legend()
    plt.axline((0, 0), (1, 0), color='black')
    plt.xlabel('n')
    plt.ylabel('x(n)')
    # plt.title('20230222HW_10828241_normal')
    plt.title('20230222HW_10828241_highPrecision')
    plt.xlim(0, n)
    plt.show()
