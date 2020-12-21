"""DEFINE_THE_LIBRARIES_WE_NEED"""
import os 
import math
import pygame
import RandomColor
from random import randint
from RandomColor import Bird , Microbe, screen, PrintScore,bird,microbe1,microbe2,microbe3,PrintPause,NewBestList

pygame.mixer.init()
pygame.mixer.music.load('game-song.mp3')
pygame.mixer.music.play(-1, 0.0)


f1 = open("record.txt", "r")
curent_record = int(f1.read())
f1.close()

def New_BEST(score):
    font = pygame.font.Font('freesansbold.ttf', 111 )
    text = font.render("NEW BEST-"+str(score-1), True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = (1280//2, 720//3)
    screen.blit(text, textRect)
    pygame.display.update()

def new_record(score):
    global curent_record
    if score > curent_record :
        New_BEST(score)
        os.remove("record.txt")
        print("File Removed!")
        f1 = open("record.txt", "w" )
        f1.write(str(score-1))

def GameOVER_PAUSE1():
    font = pygame.font.Font('freesansbold.ttf', 30 )
    text = font.render("PRESS 'R' to RESTART", True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = (1280//2, 720//1.2)
    screen.blit(text, textRect)
    pygame.display.update()

def Pause():
    font = pygame.font.Font('freesansbold.ttf', 70 )
    text = font.render("Game Paused", True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = (1280//2, 720//2)
    screen.blit(text, textRect)
    pygame.display.update()

def GameOver():
    game_over = True
    global score, ballonallive
    font = pygame.font.Font('freesansbold.ttf', 70 )
    if score > curent_record :
        text = font.render(RandomColor.newbestexpresion(), True, (255,255,255), (0,0,0))
    else :
        text = font.render("Game Over" + RandomColor.gameoverexpresion(), True, (255,255,255), (0,0,0))
    textRect = text.get_rect()
    textRect.center = (1280//2, 720//2)
    screen.blit(text, textRect)
    pygame.display.update()
    GameOVER_PAUSE1()
    new_record(score)
    while game_over:
        for event in pygame.event.get():
            if event.type == pygame.KEYDOWN:
                if event.key == pygame.K_ESCAPE:
                    pygame.quit()
                if event.key == pygame.K_r:
                    game_over = False
            if event.type == pygame.QUIT:
                pygame.quit()
    score = 0 
    RandomColor.speed = 0 
    microbe1.x = 1800
    microbe2.x = 1800
    microbe3.x = 1800
    ballonallive = False

#    pygame.quit()
    

def Touch():
    if (math.sqrt( math.pow(bird.x - microbe1.x+13.5,2) + math.pow(bird.y - microbe1.y+10,2)) < bird.radius + microbe1.radius):
            return GameOver()
    if (math.sqrt( math.pow(bird.x - microbe2.x+13.5,2) + math.pow(bird.y - microbe2.y+10,2)) < bird.radius + microbe2.radius):
            return GameOver()
    if (math.sqrt( math.pow(bird.x - microbe3.x+13.5,2) + math.pow(bird.y - microbe3.y+10,2)) < bird.radius + microbe3.radius):
            return GameOver()

running = True

ballonallive = True
score = 0 
pause = False

pygame.init()
pygame.display.set_caption('CORONA-VIRUS-GAME')#WINDOw-title
clock = pygame.time.Clock()

def main_loop():
    global running,score
    """RANDOM_COLOR_FOR_BACKGROUND"""
    color = RandomColor.integrated_color()

    """VARIABLES_USED_IN_MAIN_LOOP"""
    seconds = 60

    """GAME-LOOP"""
    while running:
        global ballonallive
        ballonallive = True
        while ballonallive:
            #increasing your score
            score +=1

            #Let our objects to moove
            microbe2.move() 
            microbe1.move()
            microbe3.move()

            #increasing speed for the microbes
            RandomColor.speed+=0.005 

            #verify if you have already touched the microbes

            #Assign some time to change backgroung color
            seconds +=1
            if seconds % 720 == 0 :
                color = RandomColor.integrated_color()

            #Get the events from game
            for event in pygame.event.get():
                global pause
                #QUIT the game
                if event.type == pygame.QUIT:
                    pygame.quit()
                    running = False
               
                #the condition below makes the ballon follow the mouse on the surface
                if event.type == pygame.MOUSEMOTION:
                    mouse_pos = event.pos
                    x,y = pygame.mouse.get_pos()
                    bird.x = x - 42
                    bird.y = y - 42
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_ESCAPE:
                        pygame.quit()
                if event.type == pygame.KEYDOWN:
                    if event.key == pygame.K_p:
                        pause = True
                while pause :
                    Pause()
                    for event in pygame.event.get():
                        if event.type == pygame.KEYDOWN:
                            if event.key == pygame.K_ESCAPE:
                                pygame.quit()
                            if event.key == pygame.K_p:
                                pause = False
                                        
                
                        

            Touch()

            # fill the screen with random color 
            screen.fill(color) 

            # draw our objects 
            microbe2.draw(screen)
            microbe1.draw(screen)
            microbe3.draw(screen)
            bird.draw(screen)

            # print our score 
            PrintScore(score)
            PrintPause()

            #update the screen
            pygame.display.update() 

            # often to update the screen 
            clock.tick(60)
        
    
main_loop()
