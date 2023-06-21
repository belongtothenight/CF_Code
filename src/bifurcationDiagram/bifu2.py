import numpy as np
import matplotlib.pyplot as plt
import sys

x0 = 0
minN = 100
maxN = 250
result = []
s = 0.05
maxC = 0.25
minC = -2
steps = 1e4

# ! ----------------
inc = -(minC - maxC) / steps

cRange = np.arange(minC, maxC, inc)

for c in cRange:
    hist = [x0]
    for n in np.arange(0, maxN, 1):
        y = hist[-1] ** 2 + c
        hist.append(y)
    result.append(hist[minN:-1])

result = np.array(result)
print(result.shape)

for i in range(len(result)):
    plt.scatter(np.repeat(cRange[i], len(result[i])), result[i], s=s, color="blue")

plt.ylabel("Xn")
plt.xlabel("c")
plt.show()
