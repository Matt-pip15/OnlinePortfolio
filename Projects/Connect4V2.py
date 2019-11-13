import os
import time

def printConnect():  # prints in rows
    for row in connect4:
        # Loop over columns.
        for column in row:
            print("|" + str(column), end="|")
        print(end="\n")
    print("---------------------")
    return None


def punishPrint(player):  # added in 2.0
    if player == 1:
        print("Cool Down: " + str(punishP1) + " turns!")
    if player == 2:
        print("Cool Down: " + str(punishP2) + " turns!")

def plop(player, nameP1, nameP2):  # changes board Piece by droping
    test = False
    row = 5
    while not test:
        if player == 1:
            col = input("Enter what col (1-7): " + str(nameP1) + "#: ")  # gets input for what collum
        else:
            col = input("Enter what col (1-7): " + str(nameP2) + "#: ")
        try:
            col = int(col)                                                              # gets input for what collum
            col -= 1  # sets the index back
            if col >= 0 and col <= 6:  # sees if index out of range!
                test = True  # exits while
                testCode.append(col)
                continue
            else:
                continue
        except ValueError:
            print("Not an integer!")

    test = False

    while not test:  # loops till value at point is 0
        if connect4[row][col] == 0:  # checks if value is zero
            connect4[row][col] = player  # sets current value to player number
            test = True  # returns true to show input went through
        elif row < 0:  # if y (x) is already full
            print("Row if full, try again!")
            return False  # returns false to show input did not go through
        else:
            row -= 1  # decrements row to go up on the array

    if player == 1:
        player1['set'].add(col + 1)
    else:
        player2['set'].add(col + 1)
    print("\n")
    printConnect()

    return True

def plopManual(col,player):
    test = False
    row = 5
    while not test:
        try:
            col = int(col)  # gets input for what collum
            col -= 1  # sets the index back
            if col >= 0 and col <= 6:  # sees if index out of range!
                test = True  # exits while
                continue
            else:
                continue
        except ValueError:
            print("Not an integer!")

    test = False

    while not test:  # loops till value at point is 0
        if connect4[row][col] == 0:  # checks if value is zero
            connect4[row][col] = player  # sets current value to player number
            test = True  # returns true to show input went through
        elif row < 0:  # if y (x) is already full
            print("Row if full, try again!")
            return False  # returns false to show input did not go through
        else:
            row -= 1  # decrements row to go up on the array
    printConnect()
    return True
def checkWinV(player):                                                          # checks for vertical win
    player1count = 0                                                            # test value for player 1
    player2count = 0                                                            # test value for player 2

    col = 0

    while col <= 6:                                                             # loops through each column
        previous = 0                                                            # previous number
        column = list()                                                         # creates list

        for row in range(6):                                                    # loops through column
            column.append(connect4[row][col])                                   # appends value to list
        column.reverse()                                                        # reverses it to set it in order
        for i in range(6):                                                      # row takes all values in list (indexed)
            value = column[i]                                                   # sets a test value (used for debugging)

            if value == 1:                                                      # adds count value if is player 1 piece
                if previous == 2:                                               # if is other player
                    player1count = 1                                            # sets value to one
                    previous = value                                            # sets previous value to current
                else:
                    player1count += 1                                           # adds value to one
                    previous = value                                            # sets previous value to current
            elif value == 2:                                                    # adds count value if is player 2 piece
                if previous == 1:                                               # checks for other value in previous
                    player2count = 1                                            # sets value to one
                    previous = value                                            # sets previous value to current
                else:
                    player2count += 1                                           # adds value to player 2
                    previous = value                                            # sets previous value to current
            else:
                player1count = 0                                                # resets count
                player2count = 0                                                # ^
                previous = value                                                # sets previous value to current

            if player == 1:                                                     # checks player value
                if player1count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command
            elif player == 2:                                                   # checks player value
                if player2count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command

        col += 1                                                                # increments to change column

    return False                                                                # exits command


def checkWinH(player):                                                          # checks for horizontal win
    player1count = 0                                                            # player 1 test value
    player2count = 0                                                            # player 2 test value

    previous = 0                                                                # previous value

    for row in connect4:                                                        # gets the first row
                                                                                # Loop over column.
        for column in row:                                                      # takes index value of row

            value = column                                                      # sets previous value

            if value == 1:                                                      # adds count value if is player 1 piece
                if previous == 2:                                               # checks for opposite value
                    player1count = 1                                            # sets value to 1 (somewhat reset)
                    previous = value                                            # updates previous value
                else:
                    player1count += 1                                           # adds 1 to player 1
                    previous = value                                            # updates previous value
            elif value == 2:                                                    # adds count value if is player 2 piece
                if previous == 1:                                               # checks for opposite value
                    player2count = 1                                            # sets value to 1 (somewhat reset)
                    previous = value                                            # updates previous value
                else:
                    player2count += 1                                           # adds 1 to player 2
                    previous = value                                            # updates previous value
            else:
                player1count = 0                                                # resets count
                player2count = 0                                                # ^
                previous = value                                                # updates previous value

            if player == 1:                                                     # checks player value
                if player1count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command
            elif player == 2:                                                   # checks player value
                if player2count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command

    return False                                                                # if no match just returns false


def checkWinDf(player):                                                         # diagonal forwards

    player1count = 0                                                            # player 1 test value
    player2count = 0                                                            # player 2 test value

    col = 0                                                                     # sets to first col
    row = 5                                                                     # sets to last row
    countRow = 0                                                                # updates row value
    countCol = 0                                                                # updates col value

    previous = 0                                                                # defines previous
    value = 0                                                                   # defines value
    newRow = 5                                                                  # starts and defines new row to bottom
    trow = False                                                                # boolean loop value
    while row >= 3:                                                             # loops till row is greater than 3
        i = 0                                                                   # Count value
        trow = False                                                            # on loop resets value to false
        while not trow:                                                          # loops till row ends

            if player == 1:                                                     # checks player value
                if player1count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command
            elif player == 2:                                                   # checks player value
                if player2count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command

            value = connect4[row][col]                                          # sets current value

            if value == 1:                                                      # adds or sets count value if is P1
                if previous == 2:                                               # checks if opposite number
                    player1count = 1                                            # sets count to 1
                    previous = value                                            # updates previous value
                else:
                    player1count += 1                                           # adds 1 to count
                    previous = value                                            # updates previous value
            elif value == 2:                                                    # adds count value if is player 2 piece
                if previous == 1:                                               # checks for opposite number
                    player2count = 1                                            # sets count to 1
                    previous = value                                            # updates previous
                else:
                    player2count += 1                                           # adds 1 to count
                    previous = value                                            # updates previous
            else:
                player1count = 0                                                # resets count
                player2count = 0                                                # ^
                previous = value                                                # updates previous


            col += 1                                                            # col moves up one
            row -= 1                                                            # row moves to the previous row
            i += 1                                                              # count goes up
            if i >= 6 or row < 0 or col > 6:                                    # checks to move on
                countCol += 1                                                   # adds 1 to count col
                col = 0 + countCol                                              # start col moves up 1
                row = newRow                                                    # sets row back to default
                if col > 6:                                                     # if column goes over the index
                    countRow += 1                                               # subtracts 1 to move row up one
                    col = 0                                                     # col is reset to 0
                    newRow = 5 - countRow                                       # new row changes value
                    row = newRow                                                # sets row to newRow
                    countCol = 0                                                # resets count col
                    trow = True                                                 # exits while

    return False


def checkWinDb(player):                                                         # diagonal backwards
    player1count = 0                                                            # player1 test value
    player2count = 0                                                            # player2 test value

    col = 6                                                                     # sets end of col
    row = 5                                                                     # set last row
    countRow = 0                                                                # modifies row
    countCol = 0                                                                # modifies col

    previous = 0                                                                # defines previous
    value = 0                                                                   # defines value
    newRow = 5                                                                  # sets newRow to last row
    trow = False                                                                # boolean exit test
    while row >= 3:                                                             # loops till is greater than 3
        i = 0                                                                   # sets count
        trow = False                                                            # resets value on loop
        while not trow:                                                         # goes till row is done
            if player == 1:                                                     # checks player value
                if player1count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command
            elif player == 2:  # checks player value
                if player2count >= 4:                                           # if value >= 4 then sets true
                    return True                                                 # exits command
            value = connect4[row][col]                                          # sets current value

            if value == 1:                                                      # adds count value if is player 1 piece
                if previous == 2:                                               # checks for previous value
                    player1count = 1                                            # sets count to 1
                    previous = value                                            # updates previous
                else:
                    player1count += 1                                           # adds 1 to count
                    previous = value                                            # updates previous
            elif value == 2:                                                    # adds count value if is player 2 piece
                if previous == 1:                                               # checks for other value
                    player2count = 1                                            # sets count to 1
                    previous = value                                            # updates previous
                else:
                    player2count += 1                                           # adds 1 to count
                    previous = value                                            # updates previous
            else:
                player1count = 0                                                # resets count
                player2count = 0                                                # ^
                previous = value                                                # updates previous

            col -= 1                                                            # goes back one column
            row -= 1                                                            # goes back one row
            i += 1                                                              # Loops goes up one
            if i >= 6 or row < 0 or col < 0:                                    # checks for nest col
                countCol += 1                                                   # adds one to count col
                col = 5 - countCol                                              # sets starting column  back 1
                row = newRow                                                    # sets row back to default row
                if col < 0:                                                     # checks to go to next row
                    countRow += 1                                               # count row adds 1
                    col = 6                                                     # column is reset to 6
                    newRow = 5 - countRow                                       # newRow has new default
                    row = newRow                                                # changes to new default
                    countCol = 0                                                # resets countCol
                    trow = True                                                 # exits loop
    return False                                                                # exits to not be true


def stab():
    intCheck = False
    while not intCheck:
        col = input("Enter the col you want to stab: ")
        try:
            col = int(col) - 1          # input for what column
            intCheck = True
        except ValueError:
            print("Was not an integer")

    row = 0                                                                     # sets row to 0
    while row < 6:                                                              # loops to set each col val to 0
        connect4[row][col] = 0
        row += 1


def poke():
    intCheck = False

    while not intCheck:
        row = input("Enter the row you want to poke: ")
        try:
            row = int(row)
            intCheck = True
        except ValueError:
            print("Was not an integer")

    col = 0                                                                     # sets row to 0
    row = 5 - (row - 1)
    while col < 6:                                                              # loops to set each col val to 0
        connect4[row][col] = 0                                                  # changes value to 0
        col += 1                                                                # changes column to tje right

    update(row)                                                                 # moves the floating pieces down


def bladeSelect(playerPunish):
    checkInput = False
    while not checkInput:
        blade = input("Would you like to: 1. Stab, 2. Poke, 3. Skip:   ")
        try:
            blade = int(blade)
            if blade > 3 or blade < 1:
                print("Not in options list!")
            else:
                checkInput = True

        except ValueError:
            continue
    if playerPunish <= 0:
        if blade == 3:
            checkInput = False
            while not checkInput:
                checkInput = plop(playerCurrent, player1['name'], player2['name'])  # asks input again
                break
            return playerPunish
        elif blade == 2:
            poke()

            checkInput = False
            while not checkInput:
                checkInput = plop(playerCurrent, player1['name'], player2['name'])  # asks input again
            return 2
        elif blade == 1:
            stab()

            checkInput = False
            while not checkInput:
                checkInput = plop(playerCurrent, player1['name'], player2['name'])  # asks input again
            return 2


    else:
        checkInput = plop(playerCurrent, player1['name'], player2['name'])  # plops value and checks if row

        while not checkInput:
            checkInput = plop(playerCurrent, player1['name'], player2['name'])  # asks input again
        return playerPunish + 1



def update(rowClr):
    col = 0                                                                     # sets starting column
    row = rowClr                                                                # set row  to the row the cleared row
    BRINGDOWN = rowClr
    while col < 6:                                                              # loop until all rows are moved down
        for i in range(6):                                                      # loops through complete rows
            if row > 0 and row - 1 > 0:                                       # Error catching
                connect4[row][col] , connect4[row-1][col] =  connect4[row-1][col] , connect4[row][col] # swaps values
            else:                                                               # out of array bounds
                break                                                           # breaks out of loop iteration
            row -= 1                                                            # moves row up by one
        col += 1                                                                # moves column to the right
        row = BRINGDOWN                                                         # sets row to the cleared row


def reset():
    # List sets an example of a reset board
    list = [[int(0) for col in range(7)], [int(0) for col in range(7)],
            [int(0) for col in range(7)], [int(0) for col in range(7)],
            [int(0) for col in range(7)], [int(0) for col in range(7)]]

    return list                                         # returns the value and sets it to the variable the comand uses


def playerSwitch(player):
    if player == 1:  # if player is player 1
        plr = 2  # switch to player 2
    elif player == 2:  # if player is player 2
        plr = 1  # switch to player 1
    return plr  # returns value


# assignments
p1 = 1  # Marker for Player 1
p2 = 2  # Marker for Player 2
playerCurrent = p1  # current players turn
gameP1 = False  # Player1 Win
gameP2 = False  # Player2 Win

player1 = {
    "name" : "Player 1",
    "wins" : 0,
    "losses" : 0,
    "set" : set()
}

player2 = {
    "name" : "Player 2",
    "wins" : 0,
    "losses" : 0,
    "set" : set()
}
connect4 = [[int(0) for col in range(7)], [int(0) for col in range(7)],
            [int(0) for col in range(7)], [int(0) for col in range(7)],
            [int(0) for col in range(7)], [int(0) for col in range(7)]]          # connect 4 board

done = False                                                                     # while loop value 1
doneD = False                                                                    # while loop value 2
check = False
player1['name'] = "Player 1"
player2['name'] = "Player 2"
testCode = []
while not done:                                                                 # game loop
    connect4 = reset()                                                          # resets board
    print("Welcome to connect 4:  \n")                                          # welcomes player
    answer = input("1. Play game (simple), 2. play (standard), 3. debug, 4. Shortcut/secrets 5.quit ")
    # gets input on what player wants ^^
    try:
        answer = int(answer)
        if answer == 1:                                                                 # starts game
                testCode.clear()
                os.system('cls')                                                        # clears screen
                playerCurrent = p1                                                     # sets player current to player 1
                game = True                                                             # game loop value
                turn = 1                                                                # sets first turn
                while game == True:                                                     # game loop
                    print("Turn " + str(turn) + ":  \n")                                # prints turn

                    if turn == 1:                                                       # shows current board on turn 1
                        printConnect()

                    switch = plop(playerCurrent, player1['name'], player2['name'])

                    while not switch:                                                   # checks for a propper input
                        switch = plop(playerCurrent, player1['name'], player2['name'])          # asks input again

                    # checks all win conditions
                    if checkWinDf(playerCurrent) == True or checkWinDb(playerCurrent) == True or \
                            checkWinH(playerCurrent) == True or checkWinV(playerCurrent) == True:
                        print("Player " + str(playerCurrent) + " has won!")  # prints win message
                        player1['wins'] += 1
                        player2['losses'] += 1
                        game = False
                        break
                    playerCurrent = playerSwitch(playerCurrent)                         # switch player

                    switch = plop(playerCurrent, player1['name'], player2['name'])

                    while not switch:
                        switch = plop(playerCurrent, player1['name'], player2['name'])          # asks input again

                    # checks all win conditons
                    if checkWinDf(playerCurrent) == True or checkWinDb(playerCurrent) == True or \
                            checkWinH(playerCurrent) == True or checkWinV(playerCurrent) == True:
                        print("Player " + str(playerCurrent) + " has won!")  #
                        game = False                                                    # sets game loop off
                        player2['wins'] += 1
                        player1['losses'] += 1
                        break                                                           # exits loop

                    turn += 1

                    playerCurrent = playerSwitch(playerCurrent)  # switches player
        elif answer == 2:                                                               # New in v2.0 Standard
                os.system('cls')                                                        # clears screen
                playerCurrent = p1                                                      # sets player  to player 1
                isSet = False                                                            # set loop value
                game = True                                                             # game loop value
                turn = 1
                winsP1 = 0                                                              # how many P1 wins
                winsP2 = 0                                                              # how many P2 wins
                winner = 0                                                              # who is the winner
                round = 1                                                               # currentRound
                rounds = False
                currentSetType = 0                                                      # currentWin count
                BEST_OF_3 = 2                                                           # constant B03
                BEST_OF_5 = 3                                                           # ConstantB05
                STR_BO3 = " best of three "
                STR_BO5 = " best of five "
                maxRounds = 0

                while not rounds:  # tests for true input.
                    maxRounds = input("1. Best of three 2. Best of 5:   ")              # Settings for set length
                    try:
                        maxRounds = int(maxRounds)
                        if maxRounds == 1 or maxRounds == 2:
                            if maxRounds == 1:
                                currentSetType = BEST_OF_3
                                rounds = True
                            elif maxRounds == 2:
                                currentSetType = BEST_OF_5
                            rounds = True
                        else:
                            continue
                    except ValueError:
                        print("Not an integer!")


                while not isSet:  # set loop

                    if winsP1 == currentSetType or winsP2 == currentSetType:            # checks for a set win
                        if currentSetType == 2:
                            if playerCurrent == 1:
                                print(str(player1['name']) + " has won the " + STR_BO3 + "set!")  # prints winner BO3
                                player1['wins'] += 1
                                player2['losses'] += 1
                                isSet = True
                            if playerCurrent == 2:
                                print(str(player2['name']) + " has won the " + STR_BO3 + "set!")  # prints winner BO3
                                player2['wins'] += 1
                                player1['losses'] += 1
                                isSet = True

                        elif currentSetType == 3:
                            if playerCurrent == 1:
                                print(str(player1['name']) + " has won the " + STR_BO5 + "set!")  # prints winner BO3
                                player1['wins'] += 1
                                player2['losses'] += 1
                                isSet = True

                            if playerCurrent == 2:
                                print(str(player2['name']) + " has won the " + STR_BO5 + "set!")  # prints winner BO3
                                player2['wins'] += 1
                                player1['losses'] += 1
                                isSet = True
                    if isSet:
                        break


                    print("Round: " + str(round))

                    playerCurrent = 1

                    punishP1 = 0  # player1 punish
                    punishP2 = 0  # player2 punish

                    print(player1['name'] + " " + str(winsP1) + "|" + str(winsP2) + " " + player2['name'])
                    while game:
                        print("Turn " + str(turn) + ":  \n")                                        # prints turn

                        if turn == 1:
                            printConnect()

                        print(player1['name'] + " has to wait " + str(punishP1) + " turns to use a blade!")
                        punishP1 = bladeSelect(punishP1)

                        # checks all win conditions
                        if checkWinDf(playerCurrent) or checkWinDb(playerCurrent) or \
                                checkWinH(playerCurrent) or checkWinV(playerCurrent):
                            print("Player " + str(playerCurrent) + " has won!")  # prints win message\
                            winsP1 += 1  # updates player 1's win count
                            break  # exits loop

                        playerCurrent = playerSwitch(playerCurrent)

                        print(player2['name'] + " has to wait " + str(punishP2) + " turns to use a blade!")
                        punishP2 = bladeSelect(punishP2)

                        # checks all win conditions
                        if checkWinDf(playerCurrent) == True or checkWinDb(playerCurrent) == True or \
                                checkWinH(playerCurrent) == True or checkWinV(playerCurrent) == True:
                            print("Player " + str(playerCurrent) + " wins round " + str(round))
                            winsP2 += 1                                                 # updates player 2's win count
                            break                                                                       # exits loop
                        playerCurrent = playerSwitch(playerCurrent)                             # switches player

                        turn += 1  # adds 1 to value

                        punishP1 -= 1
                        punishP2 -= 1

                        if punishP1 < 0:
                            punishP1 = 0
                        elif punishP2 < 0:
                            punishP2 = 0

                    connect4 = reset()
                    time.sleep(2)
                    os.system('cls')
                    turn = 1
                    round += 1

        elif answer == 3:  # enters debug
                while (doneD != True):
                    ans = input("1. plop, 2. checkWinH, 3. checkwinV, 4. checkwinD, 5. switchplayer, " + \
                                "6. printConnect, 7. Reset #: (c to clear scene)")  # gets input on what command

                    if ans == 'c':  # clears the scene
                        os.system("cls")
                        ans = input("1. plop, 2. checkWinH, 3. checkwinV, 4. checkwinD, " + \
                                    "5. switchplayer, 6. printConnect, 7. Reset #: ")  # asks what command again
                        continue  # continues

                    try:
                        ans = int(ans)
                    except ValueError:
                        break
                    if ans == 1:
                        plop(playerCurrent, player1['name'], player2['name'])
                    elif ans == 2:
                        bol = checkWinH(playerCurrent)
                        print(bol)
                    elif ans == 3:
                        bol = checkWinV(playerCurrent)
                        print(bol)
                    elif ans == 4:
                        bol = checkWinDf(playerCurrent)
                        bol2 = checkWinDb(playerCurrent)
                        print("Forwards: " + str(bol))
                        print("Back words: " + str(bol2))
                    elif ans == 5:
                        playerCurrent = playerSwitch(playerCurrent)
                    elif ans == 6:
                        printConnect()
                    elif ans == 7:
                        connect4 = reset()
                    elif ans == 8:
                        stab()
                    elif ans == 9:
                        poke()
                    else:
                        continue
        elif answer == 4:
            print("q: quit | names: change of names | blades | stats | LO")
        elif answer == 5:  # exits game
            done = True
        else:
            continue



    except ValueError:
        if answer == "names":
            player1['name'] = input("Enter player 1's name:    ")
            player2['name'] = input("Enter player 2's name:    ")
            if player1['name'] == "":
                player1['name'] = "Player 1"
            if player2['name'] == "":
                player2['name'] = "Player 2"
        if answer == "Blades":
            print("")
        if answer == "stats":
            print(player1['name'] + ": \n Wins: " + str(player1['wins']) + "\n Losses: " + str(player1['losses']))
            print(player2['name'] + ": \n Wins: " + str(player2['wins']) + "\n Losses: " + str(player2['losses']))
            print()
        if answer == "LO" or answer == "lo":
            print("Player 1: " + str(player1['set']))
            print('\n')
            print("Player 2: " + str(player2['set']))
            print('\n')



