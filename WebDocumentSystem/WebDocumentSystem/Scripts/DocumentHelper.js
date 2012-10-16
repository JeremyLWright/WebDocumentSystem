
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

function document_list_page(element, direction) {
    var pagerNode = element.parentNode.parentNode;
    var currentPage = parseInt(pagerNode.attributes["data-page"].value);
    if (direction == "next")
        currentPage = currentPage + 1;
    else if (direction == "prev" && currentPage > 1)
        currentPage = currentPage - 1;
    pagerNode.attributes["data-page"].value = currentPage;

    $('#documentListContainer').load('/Document/_DocumentList.aspx?page='+currentPage);
}
