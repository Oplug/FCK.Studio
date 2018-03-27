$(function () {
    getURL('/Home/Dashboard', 'content-wrapper')

    $("a[name='navlink']").click(function () {
        getURL($(this).attr('href'), 'content-wrapper');
        localStorage.PageId = 0;
        return false;
    })

    $("#Logout").click(function () {
        $.post("/SysManage/Logout", {}, function (response) {
            if (response == true)
                window.location = '/Home/Login';
        });
    });
})

function getURL(_url, renderid) {
    $.ajax({
        url: _url,
        type: "Post",
        success: function (data) {
            $("#" + renderid).html(data);
            $('html,body').animate({ scrollTop: 0 }, 'fast');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        }
    });
}

function setDataTable(renderid) {
    $('#' + renderid).DataTable({
        //'paging': true,
        //"iDisplayLength": 10, //默认每页数量
        //'deferRender': true,
        //'lengthChange': false,
        //'searching': true,
        //'ordering': true,
        //'info': true,
        'autoWidth': false,
        'language': DataTableLanguage
    })
}

var DataTableLanguage = {
    "sInfo": "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
    "sInfoEmpty": "显示第 0 至 0 项结果，共 0 项",
    "sSearch": "搜索:",
    "sLoadingRecords": "载入中...",
    "sProcessing": "处理中...",
    "sLengthMenu": "显示 _MENU_ 项结果",
    "sZeroRecords": "没有匹配结果",
    "sInfoFiltered": "(过滤出 _MAX_ 项结果)",
    "oPaginate": {
        "sFirst": "首页",
        "sPrevious": "上页",
        "sNext": "下页",
        "sLast": "末页"
    }
}

function alertE(msg) {
    $.alert(msg);
}

function confirmE(msg, okFun) {
    $.confirm({
        title: 'Confirm',
        content: msg,
        buttons: {
            confirm: {
                text: '是',
                btnClass: 'btn-red',
                action: okFun
            },
            cancel: {
                text: '否',
                btnClass: 'btn-blue',
            }
        }
    });
}