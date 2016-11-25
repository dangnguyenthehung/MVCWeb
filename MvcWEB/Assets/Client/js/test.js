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
    var caudung = 0;
    var diem = 0;
	
	for (i=1;i<=numberOfQuestion;i++){
		if (traloi[i]==dapan[i]) {
			caudung++;
			document.getElementById("DapAn" + i).innerHTML = "<h2 class='true'><b>Đáp án : " + dapan[i] + "</b></h2>"; //hien thi dap dan
			}
		else
			{
			document.getElementById("DapAn" + i).innerHTML = "<h2 class='false'><b>Đáp án : " + dapan[i] + "</b></h2>";// hien thi dap an
			}
	};
	// xep loai
	if (caudung == numberOfQuestion) {
		qualtity = "Xuất sắc"
	} else if (caudung >= (numberOfQuestion*0.8)){
		qualtity = "Giỏi" 
	} else if (caudung >= (numberOfQuestion*0.65)){
		qualtity = "Khá" 
	} else if (caudung >= (numberOfQuestion*0.5)) {
		qualtity = "Đạt yêu cầu"
	} else {
		qualtity = "Không đạt yêu cầu!"
	};
	diem = caudung * (10 / numberOfQuestion).toFixed(2);
	//var KQ = document.getElementById("KQ");
	var XL = document.getElementById("XepLoai");
	var TraLoi = document.getElementById("TraLoi");
	//KQ.setAttribute("value", diem);
	TraLoi.setAttribute("value", userAnswerString);
	//XL.setAttribute("value", qualtity);
	//XL.setAttribute("placeholder", qualtity);

	// hien thi ket qua
	document.getElementById("trueNumber").innerHTML = caudung;
	document.getElementById("mark").innerHTML = diem;
	document.getElementById("qualtity").innerHTML = qualtity;
	document.getElementById("ketqua").style.display = "inline";
	document.getElementById("done").style.display = "none";
	isDone = true;
	return diem;
};
function Kiemtra() {
	countArray();
	document.getElementById("checkedTracking").style.display = "inline";
	isHide = false;
}
function Kiemtra_Mobile() {
	countArray();
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
   // document.getElementById("container").removeAttribute("class");
   // document.getElementById("mobile-nav").setAttribute("class", "nav");
    document.getElementById("countdown").setAttribute("class", "countdownClock");
	countdown();
};
//window.onload = function(){
//	 document.getElementById("enterPass").addEventListener("keyup", function(event) {
//    event.preventDefault();
//    if (event.keyCode == 13) {
//        document.getElementById("btnEnter").click();
//    };
//});
//};


function hideRightPanel() {
	var resultPanel = document.getElementById("ketqua");
	var resultButtonLabel = document.getElementById("resultButtonLabel")
	if (isHide == false) {
		resultPanel.setAttribute("class","ketqua hideRightPanel");	
		setTimeout(function(){
			resultButtonLabel.setAttribute("class","fa fa-arrow-left");	
		},1000);
		
		isHide = true;
	} else {
		resultPanel.setAttribute("class","ketqua showRightPanel");
		setTimeout(function() {
			resultButtonLabel.setAttribute("class","fa fa-arrow-right");
		},1000);
		isHide = false;	
	}
}
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
		if (traloi[i] === undefined || traloi[i] === null) {
			countUnchecked++;
			textNode = document.createTextNode(i);
			node.appendChild(textNode);
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