/*
* oplug V1.0
* Depends on the following components:
* jquery-confirm v3.3.2 (http://craftpip.github.io/jquery-confirm/)
* Toastr https://github.com/CodeSeven/toastr
* iCheck v1.0.1, http://git.io/arlzeA
* Select2 4.0.5 https://select2.github.io
* jQuery JavaScript Library v3.3.1 https://jquery.com/
* Vue.js v2.5.16
*/

function oplug() {
    this.appName = null;
    this.method = {};
    this.omounted = {};
    this.datas = [];
    this.vm = {};
    this.watchs = function (fn) {
              
    }
}
oplug.prototype = {
    onInit: function () {
        var that = this;
        this.vm = new Vue({
            el: this.appName == null ? "#oplug" : this.appName,
            data: {
                datas: this.datas
            },
            filters: {
                formatDate(time) {
                    var date = new Date(time);
                    return formatDate(date, 'yyyy/MM/dd');
                }
            },
            mounted: function () { },
            methods: {},
            watch: {
                datas: {
                    handler(curVal, oldVal) {
                        this.$nextTick(function () {
                            that.watchs()
                        });
                    },
                    deep: true
                }
            }
        });
    },
    setData: function (datas) {
        Vue.set(this.vm, 'datas', datas)
    },
    request: function (arg) {
        $.ajax({
            url: arg.url,
            type: arg.type == null ? 'post' : arg.type,
            data: arg.datas,
            async: arg.async == null ? false : arg.async,
            cache: arg.cache == null ? false : arg.cache,
            headers: arg.headers,
            success: function (resp) {
                arg.success(resp);
            },
            error: function (data) { console.log(data); }
        });
    },
    post: function (url, datas, okfn, errfn, async, cache, headers) {
        $.ajax({
            url: url,
            type: 'post',
            data: datas,
            async: async == null ? false : arg.async,
            cache: cache == null ? false : arg.cache,
            headers: headers,
            success: okfn,
            error: errfn
        });
    },
    get: function (url, datas, okfn, errfn, async, cache, headers) {
        $.ajax({
            url: url,
            type: 'get',
            data: datas,
            async: async == null ? false : arg.async,
            cache: cache == null ? false : arg.cache,
            headers: headers,
            success: okfn,
            error: errfn
        });
    },
    alert: function (msg) {
        $.alert(msg);
    },
    confirm: function (msg, okFun) {
        $.confirm({
            title: '提示',
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
    },
    OK: function (msg) {
        toastr.success(msg);
    },
    Error: function (msg) {
        toastr.error(msg);
    },
    Warning: function (msg) {
        toastr.warning(msg);
    },
    setParam: function (k, v) {
        window.localStorage[k] = v;
    }
}
var oplug = new oplug();