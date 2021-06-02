$(function() {
    
    //document.ready in jQuery $();
    var clickCount;
    var matches,$matches;
    var classes = ["fourOfSpade","ace","king","queenOfSpade","joker","sixOfSpade"]
    var $panels;
    var $btnreset;
    var tempDiv1,tempDiv2;
    var fourSpade, ace, king, queen,joker,sixSpade;
    var divClasses = [];
    
    //custom function definitions
    $panels = $('.panels div')
    $matches = $('#matches');
    
    setChecks();
    pair = [];
    $panels.each(init);
    
    function init() {
        clickCount = 0;
        matches = Number($matches.text())
        let randomClass;                                               //sets up variable for randomClass
        let done = false;                                              //sets loop 
        while (!done) {
            randomClass = Math.floor(Math.random() * classes.length);  //assigns random number
            //console.log(classes[randomClass]);

            done = noRepeats(randomClass);                              
            
        }
        
        console.log("4spade: " + fourSpade);
        console.log("ace: " + ace);
        console.log("king: " + king);
        console.log("queen: " + queen);
        console.log("joker: " + joker);
        console.log("6spade: " + sixSpade);
        
        $(this).addClass('_' + classes[randomClass]);
        divClasses.push($(this));
        
    }
    
    $btnreset = $('#reset')
    function checkForMatch() {
        let tempDivClass;
        let doubleClick = false;
        let wrong = true;
        let classVal = $(this).attr('class');             
        console.log(classVal);
        
        function updateClass(div) {                                   //updates divs to image
            if (classVal[0] === '_') {                                //checks if first value is _
                classVal = classVal.slice(1);                         //slices _
                div.attr('class',classVal);                           //adds classValue
                pair.push(classVal);                                  //add current pair to class value
                clickCount += 1;                                        //increments click count    
            }            
        }                   
        
        console.log(clickCount);
        switch(clickCount) {
            case 0:
                updateClass($(this));                                //updates class to current pannel
                tempDiv1 = $(this).index();
                console.log($(this));
                break;//case one goes to case 1
            case 1:                                                  //case 1
                tempDiv2 = $(this).index();
                console.log(tempDiv2);
                /*if (tempDiv1 === tempDiv2) {
                    tempDivClass = divClasses[tempDiv1].attr('class');
                    pair = [];
                    clickCount = 0;
                    divClasses[tempDiv1].removeClass;
                    divClasses[tempDiv1].addClass('_' + tempDivClass)
                    doubleClick = true;
                } */
                
                if (doubleClick === true) {
                    break;
                }
                updateClass($(this));
                divClasses[tempDiv2].attr('class',$(this).attr('class')); //updates class to current pannel
                
                clickCount = 2;
                break;
                
            case 2:
                console.log($(this));
                console.log(classVal);
                console.log(pair[0] + "," + pair[1]);
                console.log(pair[0] === pair[1]);
                if (pair[0] === pair[1]){                            //checks if they are the same pair
                    matches++;                                       //increments to matches
                    //console.log(matches);                                
                    $matches.text(matches);                        //stes matches to text matches
                    clickCount = 0;
                    wrong = false;
                    pair = [];
                } 
                
                if (wrong === false) {
                    break;
                }
                console.log("made it to case 2!");
                
                tempDivClass = divClasses[tempDiv1].attr('class');
                 console.log(tempDivClass);
                divClasses[tempDiv1].removeClass();
                divClasses[tempDiv1].addClass("_" + tempDivClass);

                tempDivClass = divClasses[tempDiv2].attr('class');
                console.log(tempDivClass);
                divClasses[tempDiv2].removeClass();
                divClasses[tempDiv2].addClass("_" + tempDivClass);
                    
                
                clickCount = 0;

                pair = [];                                       //clears pair
                break;
                
                clickCount = 0;
            default:
                    
    

        }
        

    }
    
    function sleep(milliseconds) {
      var start = new Date().getTime();
      for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds){
          break;
        }
      }
}
    function setChecks() {
        fourSpade = 0;                                      //Resets values for all check values
        ace = 0;
        king = 0;
        queen = 0;
        joker = 0;
        sixSpade = 0;
    }
    
    function noRepeats (classNum) {
        if (Number(classNum) === 0) {                            //checks for fourspade class
            if (Number(fourSpade) < 2) {                         //makes sure there is only two of 4spade
                fourSpade++;                                     //increments 4spade

                return true;                                     //returns true
            }
        } else if (classNum === 1) {                             //checks for ace class
            if (Number(ace) < 2) {                               //checks to see if there are only two aces
                ace++;
                
                return true;                                     // returns true
            } 
        } else if (classNum === 2) {                            //checks for king class
            if (Number(king) < 2) {                             //checks to see if there are only two kings
                king++;
                
                return true;                                    // returns true
            } 
        } else if (classNum === 3) {                            // checks for queen class
            if (Number(queen) < 2) {                            //checks if there are only two queens
                queen++;
                
                return true;                                    //returns true
            }
        } else if (classNum === 4) {                            //checks for joker class
            if (Number(joker) < 2) {                            //checks if there are only two jokers
                joker++;
                
                return true;                                    //returns true
            }
        } else if (classNum === 5) {                            //checks for 
            if (Number(sixSpade) < 2) {                         //checks if there are only two sixSpades
                sixSpade++;
                
                return true;                                    //returns true
                
            }
        } 
        
        return false;                                           //returns
    }
    
    function resetGame () {
        
        setChecks();                                      //Resets check count
        $panels.each(function() {                         //removes pannel classes
           $(this).removeClass();                         //removes it
            
            $matches.text(0);                             //resets matches too 0
            pair = [];                                    //resets pair
        });
        
        matches = 0;
        divClasses = []
        $panels.each(init);                        //sets each pannel
        var i;
        for (i = 0; i <divClasses.length;i++) {
            console.log(String(i + 1) + ": "  + divClasses[i]);
        }
        
    }
    $panels.on('click',checkForMatch);
    $btnreset.on('click',resetGame);
    
});