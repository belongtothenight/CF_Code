import os
import matplotlib.pyplot as plt


def f(x0, maxValue):
    result = [x0]
    for i in enumerate(range(maxValue)):
        xn = result[-1]
        calcTemp = xn**2-2
        result.append(calcTemp)
    return result


maxValue = 30
initValue = 0.5

result1 = f(initValue, maxValue)
result2 = f(initValue+0.005, maxValue)
diff = [result1[i]-result2[i] for i in range(len(result1))]

plt.plot(result1)
plt.plot(result2)
# plt.plot(diff)
plt.legend(['x=0.5', 'x=0.5005'])
# plt.legend(['x=0.5', 'x=0.5005', 'x=diff'])
plt.xlabel('n')
plt.ylabel('x(n)')
plt.show()
