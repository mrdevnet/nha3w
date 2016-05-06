 function showPrint(url){
    width = 750; 
    height = 700; 
    top_val = (screen.height - height) / 2 - 30; 
    if (top_val < 0) { top_val = 0; } left_val = (screen.width - width) / 2; 
    window.open(url, "", "toolbar=0,location=0,status=0,menubar=0,scrollbars=1,resizable=0,width=" + width + ",height=" + height + ", top=" + top_val + ",left=" + left_val); 
    }
 