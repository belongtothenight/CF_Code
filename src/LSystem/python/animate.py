'''
This code is meant to be run in Blender.
'''

import csv
import bpy
import os

os.system('cls')

type = 'image'  # 'video' or 'image'
qNum = '3'  # '0', '1', '2', '3'
loadCoor = False  # True or False
loadRenderSetting = True  # True or False

# Load the CSV file
path = f'D:/Note_Database/Subject/CF Chaos and Fractals/CF_Code/Q{qNum}.csv'
coordinates = []
with open(path, 'r') as csvfile:
    csvreader = csv.reader(csvfile)
    for row in csvreader:
        coordinates.append(row)
# skip the first row
coordinates = coordinates[1:]
# print(coordinates)

if loadCoor:
    # create a new grease pencil object
    gpencil_data = bpy.data.grease_pencils.new("GPencil")
    gpencil = bpy.data.objects.new(gpencil_data.name, gpencil_data)
    bpy.context.collection.objects.link(gpencil)

    # create a new layer
    gp_layer = gpencil_data.layers.new("lines")

    '''
    Draw line with one frame
    '''

    # create a new frame (keyframe)
    gp_frame = gp_layer.frames.new(1)
    # gp_frame = gp_layer.frames.new(bpy.context.scene.frame_current)

    # create a new stroke
    gp_stroke = gp_frame.strokes.new()
    gp_stroke.line_width = 15
    gp_stroke.points.add(count=len(coordinates))

    # add material
    mat = bpy.data.materials.new(name="Black")
    bpy.data.materials.create_gpencil_data(mat)
    gpencil.data.materials.append(mat)

    # add points to the stroke (one frame)
    for i in range(len(coordinates)):
        gp_stroke.points[i].co = (float(coordinates[i][0]), float(
            coordinates[i][1]), float(coordinates[i][2]))

'''
end
'''
if loadRenderSetting:
    # set start, and end frame
    bpy.context.scene.frame_start = 1
    bpy.context.scene.frame_end = len(coordinates)

    # set current frame to 1 or the last frame
    bpy.context.scene.frame_current = len(coordinates)
    bpy.context.scene.render.filepath = f"D:\\Note_Database\\Subject\\CF Chaos and Fractals\\CF_Code\\Q{qNum}_blender_"

    if type == 'video':
        bpy.context.scene.render.image_settings.file_format = 'FFMPEG'
        bpy.context.scene.render.ffmpeg.format = 'MPEG4'
        bpy.context.scene.render.ffmpeg.codec = 'H264'
        bpy.context.scene.render.ffmpeg.constant_rate_factor = 'PERC_LOSSLESS'
        bpy.context.scene.render.ffmpeg.audio_codec = 'NONE'
    elif type == 'image':
        bpy.context.scene.render.image_settings.file_format = 'PNG'
        bpy.context.scene.render.image_settings.color_mode = 'RGB'
        bpy.context.scene.render.image_settings.color_depth = '16'
        bpy.context.scene.render.image_settings.compression = 0
