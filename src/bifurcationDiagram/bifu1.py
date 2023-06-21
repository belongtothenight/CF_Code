import matplotlib.pyplot as plt
import numpy as np

x0 = 0
hist = [x0]
# *********************************
for c in np.arange(-2, 0.25, 0.01):
    for n in np.arange(0, 250, 1):
        y = hist[-1] ** 2 + c
        hist.append(y)
        plt.scatter(c, y)
        print(f"c: {c}, n: {n}", end="\r")

plt.show()
