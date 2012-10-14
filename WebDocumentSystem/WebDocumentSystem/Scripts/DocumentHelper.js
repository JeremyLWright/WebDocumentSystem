﻿
function getDocumentListRowId(row) {
    return row.cells[0].children[1].innerHTML;
}


function document_row_click(event) {
    $('#DocumentNotes').load('/Document/_DocumentMetaData.aspx?DocumentId='+event.attributes["data-documentId"].value);

    //alert('Processing Document: '+getDocumentListRowId(event));
}

function document_lock_click(event) {

    $.get("/Document/_DocumentLock.aspx?DocumentId=" + event.parentElement.attributes["data-documentId"].value);

    if (eval(event.attributes["data-lock"].value)) {
        event.attributes["data-lock"].value = false;
        event.childNodes[0].attributes["src"].value = "../Images/glyphicons_204_unlock.png";
    }
    else {
        event.attributes["data-lock"].value = true;
        event.childNodes[0].attributes["src"].value = "../Images/glyphicons_203_lock.png";
    }
}