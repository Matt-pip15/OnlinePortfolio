import random

class Taunts:
    taunts = ["I am completely customizable", "No one can stop you from winning but yourself...",
                   "It would be a shame if you lost.", "Who ever one good job!"]
    def __init__(self):
        random.seed()

    def addTaunt(self):
        check = False
        while not check:
            try:
                self.taunts.append(input("Enter a taunt to add: "))
                check = True
            except ValueError:
                print("You entered an integer! Please send in a string")
        print("Taunt added!")

    def printRandomTaunt(self):
        print(self.taunts[random.randrange(len(self.taunts)-1)])




