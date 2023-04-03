'''
This code is to test the turtle drawing and closing multiple times.
Suggest this to an answer in https://stackoverflow.com/questions/36826570/how-to-close-the-python-turtle-window-after-it-does-its-code/42283059#42283059
'''

import multiprocess as mp


def draw():
    import turtle
    import tkinter
    t = turtle.Turtle()
    t.pendown()
    t.forward(100)
    turtle.bye()
    print('Drawing done.\n')


def singleRun():
    p = mp.Process(target=draw)
    p.start()
    p.join()


if __name__ == '__main__':

    # P0
    print('Processing P0')
    singleRun()

    # P1
    print('Processing P1')
    singleRun()

    # P2
    print('Processing P2')
    singleRun()

    # P3
    print('Processing P3')
    singleRun()

'''

## Draw and close multiple times

If you want to draw + close turtle process multiple times, it is possible to package the entire drawing process and the importing both tkinter & turtle code in a single process of multiprocess.

```python
import multiprocess as mp


def draw():
    import turtle
    import tkinter
    t = turtle.Turtle()
    t.pendown()
    t.forward(100)
    turtle.bye()
    print('Drawing done.\n')


def singleRun():
    p = mp.Process(target=draw)
    p.start()
    p.join()


if __name__ == '__main__':

    # P0
    print('Processing P0')
    singleRun()

    # P1
    print('Processing P1')
    singleRun()

    # P2
    print('Processing P2')
    singleRun()

    # P3
    print('Processing P3')
    singleRun()
```

The output of the above script demonstrates it can correctly draw and close multiple times with the help of multiprocess library.

```
Processing P0
Drawing done.

Processing P1
Drawing done.

Processing P2
Drawing done.

Processing P3
Drawing done.
```
'''
