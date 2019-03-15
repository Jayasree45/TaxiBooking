function fun()
{
	var el=["marine","dadar","delhielhi"];
	var gro=["Thane","Hyderabad"];
	var sel=document.getElementById('qlf');
	sel.options.length=1;
	var i;
	arrayName="";
	
	selectedArray=document.getElementById("category").value;
	if(selectedArray=="Powai")
	{
		arrayName=el;
		//break;
	}
	else if(selectedArray=="Vikroli")
	{
		arrayName=gro;
		//break;
	}
	//selectedArray.option
		for(i=0;i<arrayName.length;i++)
		{
			var opt=document.createElement('option');
			opt.innerHTML=arrayName[i];
			opt.value=arrayName[i];
			sel.appendChild(opt);
		}
}
function calculate()
{
	//string1="";
	string1=document.getElementById("qlf").value;
	alert(string1);
	var quantity=document.getElementById("a4").value;
	alert(quantity)
	//tv
	if(string1=="marine")
	{
		total=quantity*20;
		//alert(total);
		document.getElementById("a5").value=total;
	}
	//Laptop
	if(string1=="dadar")
	{
		total=quantity*30;
		//alert(total);
		document.getElementById("a5").value=total;
	}
	//phone
	if(string1=="delhi")
	{
		total=quantity*10000;
		//alert(total);
		document.getElementById("a5").value=total;
	}
	//soap
	if(string1=="Thane")
	{
		total=quantity*40;
		//alert(total);
		document.getElementById("a5").value=total;
	}
	//powder
    if (string1 == "Hyderabad") {
        total = quantity * 90;
        //alert(total);
        document.getElementById("a5").value = total;
    }
	return false;
}