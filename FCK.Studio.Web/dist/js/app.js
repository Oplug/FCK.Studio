$(function () {
    getURL('/Home/Dashboard', 'content-wrapper')

    $("a[name='navlink']").click(function () {        
        getURL($(this).attr('href'), 'content-wrapper')
        return false;
    })
})

function getURL(_url, renderid) {
    $.ajax({
        url: _url,
        type: "Post",
        success: function (data) {
            $("#" + renderid).html(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
}