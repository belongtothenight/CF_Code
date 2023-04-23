# Draw L-System

I've achieved both drawing and animating the drawing process with three methods.

1. Python generates words and draws with the Turtle library.
2. Python generates coordinates and draws with Blender.
3. Python generates coordinates and draws with Unity. (C#)

For each of the above methods, please check the subdirectories to find more details about this.

## Details of each LSystem question

```
Q0 l3 d10
w        = 'F'
newf     = 'F-F++F-F'
newb     = ''
angleInt = 0
angleInc = 60
width    = 300
height   = 100
xOffset  = 0
yOffset  = 0
scale    = 2

Q1 (2) l3 d10
w        = 'F+F+F+F'
newf     = 'F+F-F-FFF+F-F'
newb     = ''
angleInt = 0
angleInc = 90
width    = 400
height   = 450
xOffset  = 400
yOffset  = 100
scale    = 2

Q2 (3) l3 d10
w        = 'F++F++F'
newf     = 'F-F++F-F'
newb     = ''
angleInt = 0
angleInc = 60
width    = 300
height   = 350
xOffset  = 50
yOffset  = 250
scale    = 2

Q3 l3 d10
w        = 'F'
newf     = 'F-F+F+F+F-F-F-F+F'
newb     = ''
angleInt = 0
angleInc = 90
width    = 300
height   = 300
xOffset  = 50
yOffset  = 150
scale    = 2

Q4 (1) l3 d10
w        = 'F+F+F+F'
newf     = 'F+b-F-FFF+F+b-F'
newb     = 'bbb'
angleInt = 0
angleInc = 90
width    = 1000
height   = 1000
xOffset  = 200
yOffset  = 300
scale    = 2

Q5 (4) l3 d10
w        = 'F-F-F-F'
newf     = 'F-b+F-F-F-Fb-F+b-F+F+F+Fb+FF'
newb     = 'bbbb'
angleInt = 0
angleInc = 90
width    = 1300
height   = 1300
xOffset  = 500
yOffset  = -50
scale    = 2

Q6 (5) l3 d10
w        = 'F'
newf     = 'F-F+F+F+F-F-F-F+F'
newb     = ''
angleInt = 45
angleInc = 90
width    = 300
height   = 300
xOffset  = 50
yOffset  = 150
scale    = 2
```