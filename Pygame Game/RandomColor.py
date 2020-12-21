from random import randint
from random import choice
import pygame
import os
import math

"""MAIN_SCREEN"""
screen = pygame.display.set_mode((1280, 720))

"""IMAGES_TO_LOAD"""
img_path = os.path.join('C:\\Users\\eilce\\OneDrive\\Desktop', 'player.png') # import the image of the baloon
img_path1 = os.path.join('C:\\Users\\eilce\\OneDrive\\Desktop', 'mic.png')   # import the image of the microbe

"""MICROBE_INITIAL_SPEED"""
speed=0

"""COLORS"""
white = (255,255,255)
white_blue = (25,255,255)
dark_blue = (25,100,255)
orange = (255,175,0)
yellow = (200,255,0)
pink = (255,145,145)
green = (0,200,145)

"""RANDOM_SEEDS"""
colorlist = (white , white_blue, dark_blue, orange, yellow, pink, green)
GameOverList = (", maybe othertime", ", go to bed", ", CORONAVIRUS won", ", try more",", no potential",", almost good",", bad mouse?", ", can't control your hand?",", first time at pc ?",", unluky day?")
NewBestList = ("GOOD !","You are lucky !","I see you're a man of culture as well !","Unstoppable !","Insane !","GOD level !","Even better than GOD !","As nothing to do !","Cheater ?!")
"""RANDOM_FUNCTIONS"""
def generate():
    color = (randint(0,255),randint(0,255),randint(0,255))
    return color

def integrated_color():
    color = choice(colorlist)
    return color

def gameoverexpresion():
    expresion = choice(GameOverList)
    return expresion
def newbestexpresion():
    expresion = choice(NewBestList)
    return expresion

"""FROM_LOOP_FUNCTIONS"""
"""def GameOver():
    font = pygame.font.Font('freesansbold.ttf', 70 )
    text = font.render("Game Over" + gameoverexpresion(), True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = ( 1280/2, 720/2)
    screen.blit(text, textRect)
    pygame.display.update()
    while pygame.time.wait(3000) :
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_r:
                main_loop()
    pygame.quit()
    running = False
    return running"""

def PrintPause():
    white = (255, 255, 255) 
    green = (0, 255, 0) 
    blue = (0, 0, 128) 
    font = pygame.font.Font('freesansbold.ttf', 20)
    text = font.render("Press P to PAUSE", True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = ( 1100, 30)
    screen.blit(text, textRect)


def PrintScore(score):
    white = (255, 255, 255) 
    green = (0, 255, 0) 
    blue = (0, 0, 128) 
    font = pygame.font.Font('freesansbold.ttf', 20)
    text = font.render("Score= "+str(score), True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = ( 100, 30)
    screen.blit(text, textRect)

"""def Touch():
    if (math.sqrt( math.pow(bird.x - microbe1.x+13.5,2) + math.pow(bird.y - microbe1.y+10,2)) < bird.radius + microbe1.radius):
            return GameOver()
    if (math.sqrt( math.pow(bird.x - microbe2.x+13.5,2) + math.pow(bird.y - microbe2.y+10,2)) < bird.radius + microbe2.radius):
            return GameOver()
    if (math.sqrt( math.pow(bird.x - microbe3.x+13.5,2) + math.pow(bird.y - microbe3.y+10,2)) < bird.radius + microbe3.radius):
            return GameOver()"""

"""CLASSES"""
class Bird(object):  # represents the bird, not the game

    def __init__(self):
        self.image = pygame.image.load(img_path)
        # the bird's position
        self.x = 0
        self.y = 0
        self.radius = 42.5

    def draw(self, surface):
        surface.blit(self.image, (self.x, self.y))


class Microbe(object):

    def __init__(self):
        self.last = 1 # will use this in mooving function, makes the microbes not leave the surface
        self.image = pygame.image.load(img_path1)
        self.x = 1300
        self.y = randint(0,720)
        self.radius = 30.5

    def changeY():
        x1,y1 = pygame.mouse.get_pos()
        # using if-condition we will make the microbes follow our baloon position 
        if (y1>=0) and (y1<240):
            x1=randint(0,240)
        if (y1>=240) and (y1<480):
            x1=randint(240,480)
        if (y1>=480) and (y1<720):
            x1=randint(480,720)
        if (x1>680):
            x1-=60
        return x1

    def draw(self, surface):
        """ Draw on surface """
        surface.blit(self.image, (self.x, self.y))

    def move(self):
        # here we create the mooving function
        global speed # notice the using of a global variable
        direction = randint(1,1000) % 2
        x1,y1 = pygame.mouse.get_pos()
        x1 = Microbe.changeY()
        if self.last == 1  :
            dist = randint(randint(3,15),randint(15,25)) # it is the microbes speed 
            self.x -= dist + speed # here we make sure it will increase by passing loops 
            if self.x <= -70:
                self.last = 0
                self.y = x1 # x1 is the random number for y in the area op mouse_pos
                # below we use a random variable to change/not change the mooving direction of the microbe 
                
                if (direction == 0):
                    self.last = 1
                    self.x = 1270
                else:
                    self.last = 0
                    self.x = -60
        else:
            dist = randint(randint(-31,-12),randint(-12,-1)) # same comm as in line 33
            self.x -= dist - speed  # same comm as in line 34
            if self.x >= 1270:
                self.last = 1
                self.y = x1

                if (direction == 0):
                    self.last = 1
                    self.x = 1270
                else:
                    self.last = 0
                    self.x = -60

"""INSTANCES"""
bird = Bird()
microbe2 = Microbe() 
microbe1 = Microbe()
microbe3 = Microbe()


    
