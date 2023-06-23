import numpy as np
import matplotlib.pyplot as plt
import sys

minN = 0
maxN = 250
c = -2
x0_0 = 0.1
x0_1 = 0.11
hist = [x0_0]
hist1 = [x0_1]

for n in range(minN, maxN):
    y = hist[-1] ** 2 + c
    hist.append(y)
    print(f"n: {n} y: {y}", end="\r")
hist = hist[0:-1]


for n in range(minN, maxN):
    y = hist1[-1] ** 2 + c
    hist1.append(y)
    print(f"n: {n} y: {y}", end="\r")
hist1 = hist1[0:-1]

print()
plt.xlabel("n")
plt.ylabel("Xn")
plt.plot(range(minN, maxN), hist)
plt.plot(range(minN, maxN), hist1)
plt.show()
