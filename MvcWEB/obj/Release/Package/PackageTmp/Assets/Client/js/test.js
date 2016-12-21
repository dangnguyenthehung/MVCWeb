		var traloi=new Array();
		var isDone = false;
		var isHide = true;
		var qualtity = "";
		var numClick = 0;
		var time = 60;
		var numberOfQuestion = 100;
		
function LamXong(){
    var userAnswerString = "";
    var i = 1;
    for (i = 1; i <= numberOfQuestion; i++) {
        if (traloi[i] == null) {
            traloi[i] = "-";
        }
        userAnswerString += i + traloi[i] + ".";
    }
    var TraLoi = document.getElementById("TraLoi");
    TraLoi.setAttribute("value", userAnswerString);
    isDone = true;
};
function Kiemtra() {
	document.getElementById("checkedTracking").style.display = "inline";
	isHide = false;
	countArray();
}
function Kiemtra_Mobile() {
	var navButtonLabel = document.getElementById("navButtonLabel");
	if (isHide == true && numClick == 0) {
		document.getElementById("checkedTracking").style.display = "inline";	
		setTimeout(function() {
			navButtonLabel.setAttribute("class","fa fa-arrow-left");
		},1000);
		isHide = false;
		numClick++;
	} else {
		hideLeftPanel_Mobile();
	}
	countArray_mobile();
}
function countdown(){ // dong ho dem nguoc
     var min = time;
     var sec = 00;
     var timeout = document.getElementById("timeout");
     var clock =  setInterval(function(){
       document.getElementById("timer").innerHTML = min +" : " + sec ;
       if (min == 0 & sec == 0)
         {
         	isDone = true;
            timeout.style.display = "inline";
            setTimeout(function(){
            	timeout.style.display = "none";
            }, 2000); // hien thi HET GIO khi het t.gian
            LamXong();       
            stopWatch(isDone); 
         };
       if(sec == 00)
       {
         min--;
         sec = 59;
         sec++;
       };
       sec--;
       stopWatch(isDone);
      },1000);
    function stopWatch (isDone){
    	if (isDone) {    		
     	clearInterval(clock); // stop dong ho
    	};
     };
    };
function begin (){
    document.getElementById("begin").style.display = "none";
    //document.getElementById("toggleButton").removeAttribute("class");
    //document.getElementById("toggleButton").setAttribute("class", "hamburger is-closed hidden-lg hidden-md");
    document.getElementById("countdown").setAttribute("class", "countdownClock");
	countdown();
};

function hideLeftPanel() {
	var checkedTracking = document.getElementById("checkedTracking");
	var trackingButtonLabel = document.getElementById("trackingButtonLabel")
	if (isHide == false) {
		checkedTracking.setAttribute("class","checkedTracking hideLeftPanel");	
		setTimeout(function(){
			trackingButtonLabel.setAttribute("class","fa fa-arrow-right");	
		},1000);
		
		isHide = true;
	} else {
		checkedTracking.setAttribute("class","checkedTracking showLeftPanel");
		setTimeout(function() {
			trackingButtonLabel.setAttribute("class","fa fa-arrow-left");
		},1000);
		isHide = false;	
	}
}
function hideLeftPanel_Mobile() {
	var checkedTracking = document.getElementById("checkedTracking");
	var navButtonLabel = document.getElementById("navButtonLabel");
	if (isHide == false) {
		checkedTracking.setAttribute("class","checkedTracking hideLeftPanel");	
		setTimeout(function(){
			navButtonLabel.setAttribute("class","fa fa-bars");	
		},1000);
		
		isHide = true;
	} else {
		checkedTracking.setAttribute("class","checkedTracking showLeftPanel");
		setTimeout(function() {
			navButtonLabel.setAttribute("class","fa fa-arrow-left");
		},1000);
		isHide = false;	
	}
}
function countArray() {
	var countUnchecked = 0;
	var uncheckList = document.getElementById("uncheckList");
	uncheckList.innerHTML = "";
	for (i=1;i<=numberOfQuestion;i++) {
	    var node = document.createElement("li");
	    var textNode;
	    var nodeLink = document.createElement("a");
	    var nodeAttr = document.createAttribute("href");
	    
		if (traloi[i] === undefined || traloi[i] === null) {
		    countUnchecked++;
		    nodeAttr.value = "#" + i;
		    nodeLink.setAttributeNode(nodeAttr);
		    textNode = document.createTextNode(i);
		    nodeLink.appendChild(textNode);
			node.appendChild(nodeLink);
			uncheckList.appendChild(node);
			console.log(i);
		}
	}


	if (countUnchecked == 0) {
		textNode = document.createTextNode("Đã trả lời đầy đủ!");
		node.appendChild(textNode);
		uncheckList.appendChild(node);
	}
}

function countArray_mobile() {
    var countUnchecked = 0;
    var uncheckList_mobile = document.getElementById("uncheckList_mobile");
    uncheckList_mobile.innerHTML = "";
    for (i = 1; i <= numberOfQuestion; i++) {
        var node = document.createElement("li");
        var textNode;
        var nodeLink = document.createElement("a");
        var nodeAttr = document.createAttribute("href");

        if (traloi[i] === undefined || traloi[i] === null) {
            countUnchecked++;
            nodeAttr.value = "#" + i;
            nodeLink.setAttributeNode(nodeAttr);
            textNode = document.createTextNode(i);
            nodeLink.appendChild(textNode);
            node.appendChild(nodeLink);
            uncheckList_mobile.appendChild(node);
            console.log(i);
        }
    }


    if (countUnchecked == 0) {
        textNode = document.createTextNode("Đã trả lời đầy đủ!");
        node.appendChild(textNode);
        uncheckList_mobile.appendChild(node);
    }
}