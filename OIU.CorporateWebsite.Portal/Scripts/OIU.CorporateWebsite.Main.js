/// <reference path="jquery-1.8.2.intellisense.js" />
/* ==============================================================================
 * 类名称：OIU.CorporateWebsite.Main.js
 * 类描述：项目主要JS文件
 * 创建人：jason
 * 创建时间：2013/10/14 23:35:27
 * 修改人：
 * 修改时间：
 * 修改备注：
 * @version 1.0
 * ==============================================================================*/

//jQuery插件serializeFormJSON
//序列化表单元素并转化为JSON
(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);
/** 
* 对json日期字符串进行格式化， 
* @param jsondate 要格式化的json日期字符串 
* @return 
*/
function formatJSONDate(jsonDate) {
    return formatDate(new Date(parseInt(jsonDate.substr(6))), "yyyy-MM-dd HH:mm:ss");
}

/** 
* 对日期进行格式化， 
* @param date 要格式化的日期 
* @param pattern 进行格式化的模式 
*     支持的模式字母有： 
*     y:年, 
*     M:年中的月份(1-12), 
*     d:月份中的天(1-31), 
*     H:小时(0-23), 
*     h:小时(0-12), 
*     m:分(0-59), 
*     s:秒(0-59), 
*     S:毫秒(0-999), 
*     E:星期(以汉语表示), 
*     e:星期(以英文表示), 
*     A:上午/下午标识, 
*     a:AM/PM标识 
* @return 
*/
function formatDate(date, pattern) {
    var d;
    if ((d = parseDate(date)) == null) {
        return "";
    }
    if (!pattern) {
        pattern = "yyyy-MM-dd";
    }
    var arrWeek = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六", "Sunday", "Monday", "Tuesday", "Tuesday", "Thursday", "Friday", "Saturday"];
    var value = new Object();
    value["y"] = parseString(date.getFullYear());
    value["M"] = parseString(date.getMonth() + 1);
    value["d"] = parseString(date.getDate());
    value["H"] = parseString(date.getHours());
    value["h"] = parseString(value["H"] > 12 ? (value["H"] - 12) : value["H"]);
    value["m"] = parseString(date.getMinutes());
    value["s"] = parseString(date.getSeconds());
    value["S"] = parseString(date.getMilliseconds());
    value["E"] = arrWeek[date.getDay()];
    value["e"] = arrWeek[date.getDay() + 7];
    value["a"] = (value["H"] > 12 ? "PM" : "AM");
    value["A"] = (value["H"] > 12 ? "下午" : "上午");
    var result = "";
    var i = 0;
    var hasE = false;//是否出现过星期  
    var hasAMPM = false;//是否出现过上午下午  
    while (i < pattern.length) {
        var c = pattern.charAt(i++);
        var lc = c;//记录本次要处理的字母,如'y'  
        var tmpStr = c;//本次在处理的字母格式,如'yyyy'  
        while (i < pattern.length && (c = pattern.charAt(i)) == lc) {
            tmpStr += c;
            i++;
        }
        if (value[lc] != "" && value[lc] != null && value[lc] != "undefined") {
            //本次要处理的字母是模式母  
            if ((lc == "E" || lc == "e") && !hasE) {
                //星期  
                result += value[lc];
                hasE = true;
            } else if (lc == "E" || lc == "e") {
                result += tmpStr;
            } else if ((lc == "a" || lc == "A") && !hasAMPM) {
                //上下午  
                result += value[lc];
                hasAMPM = true;
            } else if ((lc == "a" || lc == "A")) {
                result += tmpStr;
            } else {
                //如果是 单个的日期，月份，小时，分，秒的字符串，不能再进行字符串的截取操作  
                if (tmpStr == "d" || tmpStr == "M" || tmpStr == "H" || tmpStr == "h" || tmpStr == "m" || tmpStr == "s") {
                    result += value[lc];
                } else {
                    result += value[lc].fillChar(tmpStr.length);
                }
            }
        } else {//非模式字母，直接输出  
            result += tmpStr;
        }
    }
    return result;
}

function parseDate(value) {
    var date = null;
    if (Date.prototype.isPrototypeOf(value)) {
        date = value;
    } else if (typeof (value) == "string") {
        date = new Date(value.replace(/-/g, "/"));
    } else if (value != null && value.getTime) {
        date = new Date(value.getTime());
    }
    ;
    return date;
};

/** 
 * 将对象转换为字符串类型 
 */
function parseString(value) {
    if (value == null) {
        return "";
    } else {
        return value.toString();
    }
};
String.prototype.fillChar = function (length, mode, char) {
    if (!char) {
        char = "0";
    }
    if (this.length > length) {//比实际想要的长度更大  
        if (mode == "after") {//如果是要在后面填充，截取的时候会将会后面的部分截取掉  
            return this.substr(0, length);
        } else {//默认截取前一部分的数据  
            return this.substr(this.length - length, length);
        }
    }
    var appendStr = "";
    for (var i = 0; i < (length - this.length) / char.length; i++) {
        appendStr += char;
    }
    if (mode == "after") {
        return this + appendStr;
    }
    else {
        return appendStr + this;
    }
};