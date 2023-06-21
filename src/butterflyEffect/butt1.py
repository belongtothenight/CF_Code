import numpy as np
import matplotlib.pyplot as plt
import sys

x0 = 0
minN = 0
maxN = 250
c = -2
x0 = 0.1
s = 1
hist = [0.1]
hist1 = [0.11]

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
# plt.scatter(range(minN, maxN), hist, s=s, color="blue")
plt.plot(range(minN, maxN), hist)
plt.plot(range(minN, maxN), hist1)
plt.show()
