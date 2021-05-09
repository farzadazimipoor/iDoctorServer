function jGrid2(gridName,url) {
    this.gridName = gridName;
    this.url = url;
    this._dataSource;
    this._pageSize = 200000;
    this._pageNumber = 1;
    this._pageCount = 0;
    this.afterEditCell;
    this._tempDataSource;
    this.LastRowIndex;
    this.activedRowIndex;
    this.afterCellClick;
    this.afterRefreshGrid;
    this.firstColumn;
    this.afterAddNewRecord;    
    this.deleteUrl;
    this.filterParameters;
    this._headerColumnsList = window["_headerColumnsList_"+gridName];
    this.intiateJGrid2 = function () {      
        this.bindNext();
        this.bindLast();
        this.bindPrev();
        this.bindFirst();
        this.getGridDataSource();
        // this.bindRowClick();
    };
    var thisClass = this;
    this.getGridDataSource = function () {
        $("#" + this.gridName + " .waiting").css("display", "block");
        if (thisClass.filterParameters) {
            $.post(this.url, { filterParameters: thisClass.filterParameters }, function (data) {              
                thisClass._dataSource = data;
                thisClass.refreshGrid();
            });
        }
        else {
            console.log(this.url);
            $.get(this.url, function (data) {               
                thisClass._dataSource = data;
                thisClass.refreshGrid();
            });
        }
    
    };
    //this.filter = function (link, obj) {
    //    $("#" + this.gridName + " .waiting").css("display", "block");
    //    $.post(link, obj, function (data) {
    //        thisClass._dataSource = data;
    //        thisClass.refreshGrid();
    //    });
    //};
    this.calculatePageCount = function () {
        thisClass._pageCount = parseInt(thisClass._dataSource.length / thisClass._pageSize) + (thisClass._dataSource.length % thisClass._pageSize != 0 ? 1 : 0);
    };
    this.refreshGrid = function (focusedIndex, focusedColumn) {      
        $("#" + this.gridName + " .waiting").css("display", "block");
        removeDeletedItems();
        refreshRowIndex();
        thisClass.calculatePageCount();
        thisClass.LastRowIndex = thisClass._dataSource.length;
        thisClass._tempDataSource = thisClass._dataSource.slice((thisClass._pageNumber - 1) * thisClass._pageSize, (thisClass._pageNumber) * thisClass._pageSize);
        var tbodyHtml = "";
        $.each(thisClass._tempDataSource, function (index, row) {
            var originIndex;
            if (!row.isDeleted) {
                 originIndex = thisClass._tempDataSource[index].notChangedIndex - 1;
            var tr = "<tr data-rowindex='" + originIndex + "'>";
            tr += thisClass.createIsChecked(row);
            tr += thisClass.createRowIndex(row);
            // tr += createIsChecked(row);
            for (var key in row) {               
                var columnInfo = thisClass.findInArr(key);   
                if (columnInfo && columnInfo.Name !== "rowIndex" && columnInfo.Name !== "isChecked") {
                    if (columnInfo.Show === 'True') {
                        var td = columnInfo.Width ? "<td style='width:" + columnInfo.Width + "'>" : "<td>";
                        if (columnInfo.ReadOnly === "True" && columnInfo.Type !== "custome") {
                            // td += row[key];
                            td += thisClass.renderReadOnlyTextBox(originIndex, columnInfo.Name, row[key]);
                        }
                        else {
                            if (columnInfo.DropDown) {
                                td += thisClass.renderDropDown(originIndex, columnInfo.Name, row[key], columnInfo.DropDownDataSource, columnInfo.IsRequired, columnInfo.ReadOnlyGrid);
                            }
                            else if (columnInfo.Type === "int" || columnInfo.Type === "string" || columnInfo.Type === "float" || columnInfo.Type === "decimal") {
                                td += thisClass.renderTextBox(originIndex, columnInfo.Name, row[key], columnInfo.IsRequired, columnInfo.ReadOnlyGrid);
                            }
                            else if (columnInfo.Type === "bool") {
                                td += thisClass.renderCheckBox(originIndex, columnInfo.Name, row[key], columnInfo.IsRequired, columnInfo.ReadOnlyGrid);
                            }
                            else if (columnInfo.Type === "date") {
                                td += thisClass.renderDatePicker(originIndex, columnInfo.Name, row[key], columnInfo.IsRequired, columnInfo.ReadOnlyGrid);
                            }
                            else if (columnInfo.Type === "custome") {
                                td += thisClass.renderCustome(originIndex, columnInfo.Name, columnInfo.CustomeRender);
                            }
                            else if (columnInfo.Type === "delete") {
                                td += thisClass.renderDelete(originIndex, columnInfo.Name, row[key]);
                            }
                        }
                        td += "</td>";
                        tr += td;
                    }
                }
            }
            tr += "</tr>";
            tbodyHtml += tr;
            }

        });       
        $("#" + gridName + " tbody").html(tbodyHtml);
        Awro.Initializer.Select2("#" + gridName + " tbody");
        $("#" + gridName + " .paging-num").val(thisClass._pageNumber + " - " + thisClass._pageCount);
        thisClass.bindGridMovement();
        thisClass.bindOnClick();
        thisClass.bindRowClick();
        if (thisClass.afterRefreshGrid)
            Awro.Function.Call(thisClass.afterRefreshGrid);
        //setTimeout(function () {
        //    $("#" + gridName + " .waiting").css("display", "none");
        //}, 200);
        $("#" + gridName + " .waiting").css("display", "none");
        if (focusedColumn && focusedIndex) {
            $("#" + gridName + " [data-column='" + focusedColumn + "'][data-index='" + focusedIndex + "']").focus();
            if (thisClass.afterAddNewRecord) {
                Awro.Function.Call(thisClass.afterAddNewRecord, focusedIndex);
            }
        }     

    };
    function removeDeletedItems() {
        thisClass._dataSource = jQuery.grep(thisClass._dataSource, function (value) {
            return value.IsDeleted !== true;
        });
    }
    function refreshRowIndex() {
        var rowIndex = 1;
        var notChangedRowIndex = 1;
        $.each(thisClass._dataSource, function (index, row) {
            row.notChangedIndex = notChangedRowIndex;
            if (!row.isDeleted) {
                row.rowIndex = rowIndex;
                rowIndex++;
            }      
            notChangedRowIndex++;
        });
    }
    this.createRowIndex = function (row) {
        var rowIndex = thisClass.findInArr("rowIndex");
        if (rowIndex) {
            var rowIndexTd = rowIndex.Width ? "<td style='width:" + rowIndex.Width + "'>" : "<td>";
            rowIndexTd += row["rowIndex"];
            rowIndexTd += "</td>";
            return rowIndexTd;
        }
    };
    this.createIsChecked = function (row) {
        var isChecked = thisClass.findInArr("isChecked");
        if (isChecked) {
            var index = parseInt(row["rowIndex"]) - 1;
            var td = isChecked.Width ? "<td style='width:" + isChecked.Width + "'>" : "<td>";
            return td + thisClass.renderCheckBox(index, "IsChecked", false) + "</td>";
        }
    };
    this.renderDropDown = function (index, id, value, source, isRequired, isReadOnlyGrid) {
        //var rowIndex = thisClass._dataSource[index].rowIndex;
        var dropDownDataSource = Awro.Function.Call(source);
        var requiredClass = isRequired === "True" ? "class='form-control isRequired select2'" : "class='form-control select2'";
        var disabled = isReadOnlyGrid && isReadOnlyGrid == "True" ? "disabled='disabled'" : "";
        var html = "<select " + disabled+" " + requiredClass + "  data-column='" + id + "' data-index='" + index + "' onchange='" + gridName + ".onChangeRow(this,\"" + index + "\",\"" + id + "\")' id='" + index + "_" + id + "' name='" + index + "_" + id + "'>";
        if (dropDownDataSource) {
            $.each(dropDownDataSource, function (index, item) {               
                if (item.Value != undefined && value != undefined && item.Value.toString().toLowerCase() === value.toString().toLowerCase()) {
                    html += "<option selected='selected' value='" + item.Value + "'>" + item.Text + "</option>";
                }
                else {
                    html += "<option value='" + item.Value + "'>" + item.Text + "</option>";
                }
            });
        }
        html += "<select>";
        return html;
    };
    this.renderTextBox = function (index, id, value, isRequired,isReadOnlyGrid) {
       // var rowIndex = thisClass._dataSource[index].rowIndex;
        var requiredClass = isRequired === "True" ? "class='form-control isRequired'" : "class='form-control'";
        var disabled = isReadOnlyGrid && isReadOnlyGrid == "True" ? "disabled='disabled'" : "";
        if (value === null)
            value = "";
        return "<input " + disabled+" autocomplete='off' " + requiredClass + "  data-column='" + id + "' data-index='" + index + "' onchange='" + gridName + ".onChangeRow(this,\"" + index + "\",\"" + id + "\")' type='text' id='" + index + "_" + id + "' name='" + index + "_" + id + "' value='" + value + "' />";
    };
    this.renderReadOnlyTextBox = function (index, id, value) {
        if (value === null)
            value = "";
        return "<input readonly class='form-control readonly' data-column='" + id + "' data-index='" + index + "' onchange='" + gridName + ".onChangeRow(this,\"" + index + "\",\"" + id + "\")' type='text' id='" + index + "_" + id + "' name='" + index + "_" + id + "' value='" + value + "' />";
    };
    this.renderDatePicker = function (index, id, value, isRequired, isReadOnlyGrid) {         
        var cssClass = isRequired === "True" ? "class='flatpicker form-control isRequired'" : "class='flatpicker form-control'";
        var disabled = isReadOnlyGrid && isReadOnlyGrid == "True" ? "disabled='disabled'" : "";
        if (value === null)
            value = "";
        return "<input " + disabled+" autocomplete='off' " + cssClass + " data-column='" + id + "' data-index='" + index + "' onchange='" + gridName + ".onChangeRow(this,\"" + index + "\",\"" + id + "\")' type='text' id='" +id+  "_" + index + "' name='" + id + "_" + index + "' value='" + value + "' />";
    };
    this.convertDateToShamsi = function (value) {
        var jDate = "";
        if (!(!value || value === '')) {
            //var valueWithSlash = value.indexOf("/") > 0;          
            var dateObj = new Date(value);
            var month = dateObj.getUTCMonth() + 1;//valueWithSlash ?parseInt(value.split('/')[1]) : dateObj.getUTCMonth() + 1; //months from 1-12
            var day = dateObj.getUTCDate() + 1;//valueWithSlash?parseInt(value.split('/')[2]): dateObj.getUTCDate();
            var year = dateObj.getUTCFullYear();//valueWithSlash ?parseInt(value.split('/')[0]) : dateObj.getUTCFullYear();
            if (year > 1900) {
                var jalaliDate = toJalaali(year, month, day);
                jDate = jalaliDate.jy + "/" + (jalaliDate.jm < 10 ? "0" + jalaliDate.jm : jalaliDate.jm) + "/" + (jalaliDate.jd < 10 ? "0" + jalaliDate.jd : jalaliDate.jd);
            }
        }
        return jDate;
    };
    this.renderCheckBox = function (index, id, value, isReadOnlyGrid) {
        var fieldId = index + "_" + id;
        var checked = value ? "checked='checked'" : "";
        var disabled = isReadOnlyGrid && isReadOnlyGrid == "True" ? "disabled='disabled'" : "";
        //return "<div class='checkbox-bird d-inline-block'>" +
        //    "<input data-column='" + id + "' data-index='" + index + "' onchange='" + gridName + ".onChangeRow(this,\"" + index + "\",\"" + id + "\")' type='checkbox' id='" + fieldId +
        //    "' name='" + index + "_" + id + "' value='" + value + "'" + checked + " />" +
        //    "<label  for='" + fieldId + "'></label>" +
        //    "</div>";
        return "<div class='checkbox-bird mb-0'>" +
            "<input " + disabled+" class='checkBox' data-column='" + id + "' data-index='" + index + "' onchange='" + gridName + ".onChangeRow(this,\"" + index + "\",\"" + id + "\")' type='checkbox' id='" + fieldId +
            "' name='" + index + "_" + id + "' value='" + value + "'" + checked + " />" +
            "<label  for='" + fieldId + "'></label>" +
               "</div>";
    };
    this.renderCustome = function (index, id, value) {
        //var result = window[value](index);    
        var result=Awro.Function.Call(value, index);
        return result;
    };
    this.renderDelete = function (index, id, value) {
        //var idValue = thisClass._dataSource[index].id;
        //var result = "<div class='btn-group btn-toolbar' role='group' aria-label='Basic example'><button class='btn btn-danger-outline btn-sm' type='button' onclick='Awro.Form.DeleteItem(\"" + thisClass.deleteUrl + "\", {id:\"" + idValue + "\"}, function(){" + thisClass.gridName + ".intiateJGrid2()},  \"#" + thisClass.gridName + "\")' title='Delete'><span class='glyphicon glyphicon-trash'></span></button></div>";
        var result = "<div class='w-100 text-center'><button class='btn btn-danger-outline btn-inline m-0 btn-sm' type='button' onclick='" + thisClass.gridName+".clientSideDelete(" + index+")' title='Delete'><span class='glyphicon glyphicon-trash'></span></button></div>";
        return result;
    };
    this.clientSideDelete = function clientSideDelete(index) {
        var idValue = thisClass._dataSource[index].id;
        thisClass._dataSource[index].isDeleted = true;
        if (thisClass._dataSource[index].isNew === false) {
            Awro.Form.DeleteItem(thisClass.deleteUrl, { id: idValue }, function () { thisClass.refreshGrid(); }, "#" + thisClass.gridName);
        }
        else {
            thisClass.refreshGrid();
        }
    };
    this.findInArr = function (columnName) {
        var result;
        for (var index in thisClass._headerColumnsList) {
            if (thisClass._headerColumnsList[index].Name.toLowerCase() === columnName.toLowerCase()) {
                result = thisClass._headerColumnsList[index];
                break;
            }
        }
        return result;
    };
    this.findColumnIndex = function (columnName) {
        var result;
        for (var index in thisClass._headerColumnsList) {
            if (thisClass._headerColumnsList[index].Name == columnName) {
                result = index;
                break;
            }
        }
        return result;
    };
    this.bindNext = function () {
        $("#" + gridName + " .Next").click(function () {
            if (thisClass.validate()) {
                thisClass._pageNumber = thisClass._pageNumber + 1;
                if (thisClass._pageNumber > thisClass._pageCount)
                    thisClass._pageNumber = 1;
                thisClass.refreshGrid();
            }
        });
    };
    this.bindLast = function () {
        $("#" + gridName + " .Last").click(function () {
            if (thisClass.validate()) {
                thisClass.goToLastPage();
            }
        });
    };
    this.goToLastPage = function (focusedIndex, focusedColumn) {
        thisClass.calculatePageCount();
        thisClass._pageNumber = thisClass._pageCount;
        thisClass.refreshGrid(focusedIndex, focusedColumn);
    };
    this.bindPrev = function () {
        $("#" + gridName + " .Previous").click(function () {
            if (thisClass.validate()) {
                thisClass._pageNumber = thisClass._pageNumber - 1;
                if (thisClass._pageNumber < 1)
                    thisClass._pageNumber = thisClass._pageCount;
                thisClass.refreshGrid();
            }
        });
    };
    this.bindFirst = function () {
        $("#" + gridName + " .First").click(function () {
            if (thisClass.validate()) {
                thisClass._pageNumber = 1;
                thisClass.refreshGrid();
            }
        });
    };
    this.bindGridMovement = function () {
        $("#" + gridName).find("input").keyup(function (event) {
            var index = $(this).data("index");
            var column = $(this).data("column");
            var columnIndex = thisClass.findColumnIndex(column);
            if (event.key === "Enter") {
                thisClass.moveToNext(index, columnIndex);
            }
            else if (event.key === "ArrowDown") {
                thisClass.moveToDown(index, columnIndex);
            }
            else if (event.key === "ArrowUp") {
                thisClass.moveToUp(index, columnIndex);
            }
        });
        $("#" + gridName + ' select').keyup(function (event) {
            if (event.keyCode === 13) {
                var index = $(this).data("index");
                var column = $(this).data("column");
                var columnIndex = thisClass.findColumnIndex(column);
                thisClass.moveToNext(index, columnIndex);
            }
        });
        thisClass.diableSelectEnter();
    };
    this.diableSelectEnter = function () {
        $("#" + gridName + ' select').keypress(function (event) {
            if (event.keyCode === 13) {
                event.preventDefault();
            }
        });
    };
    this.moveToNext = function (index, columnIndex) {
        if (parseInt(columnIndex) < (thisClass._headerColumnsList.length - 1)) {
            var nextIndex = parseInt(columnIndex) + 1;
            for (; nextIndex < thisClass._headerColumnsList.length; nextIndex++) {
                if (thisClass._headerColumnsList[nextIndex].ReadOnly === "False" && thisClass._headerColumnsList[nextIndex].Show == "True") {
                    break;
                }
            }
            if (nextIndex < thisClass._headerColumnsList.length) {
                var nextColumn = thisClass._headerColumnsList[nextIndex].Name;
                $("#" + gridName + " [data-column='" + nextColumn + "'][data-index='" + index + "']").focus();
            }
            else {
                thisClass.goToFirstColumn(index);
            }
        }
        else if (index < (tempDataSource.length - 1)) {
            thisClass.goToFirstColumn(index);
        }
    };
    this.goToFirstColumn = function (index) {
        var nextColumn;
        if (!thisClass.firstColumn) {
            for (var i = 0; i <= thisClass._headerColumnsList.length; i++) {
                if (thisClass._headerColumnsList[i].Show === 'True' && thisClass._headerColumnsList[i].ReadOnly == "False") {
                    nextColumn = thisClass._headerColumnsList[i].Name;
                    break;
                }
            }
        }
        else
            nextColumn = thisClass.firstColumn;
        var nextIndex = parseInt(index) + 1;
        $("#" + gridName + " [data-column='" + nextColumn + "'][data-index='" + nextIndex + "']").focus();
    };
    this.moveToUp = function (index, columnIndex) {
        if (index > 0) {
            var columnName = thisClass._headerColumnsList[columnIndex].Name;
            var nextIndex = parseInt(index) - 1;
            $("#" + gridName + " [data-column='" + columnName + "'][data-index='" + nextIndex + "']").focus();
        }
    };
    this.moveToDown = function (index, columnIndex) {
        var nextIndex = parseInt(index) + 1;
        var columnName = thisClass._headerColumnsList[columnIndex].Name;
        var length = getDataSourceLength();
        if (nextIndex < length) {
            $("#" + gridName + " [data-column='" + columnName + "'][data-index='" + nextIndex + "']").focus();
        }
        //else {
        //    thisClass.addNew(nextIndex, columnName);
        //}
    };
    function getDataSourceLength() {
        var length = 0;
        $.each(thisClass._dataSource, function (index, row) {
            if (!row.IsDeleted)
                length++;
        });
        return length;
    }
    this.onChangeRow = function (element, index, columnName) {      
        var id = this._dataSource[index].id;  
        var value = $(element).hasClass("checkBox") ? $(element).is(":checked") : $(element).val();
        $.each(thisClass._dataSource, function (index, row) {  
            if (row.id === id) {
                row[columnName] = value;
                row["isEdited"] = true;
                row["isEmptyRow"] = false;
                if (thisClass.afterEditCell) {
                    Awro.Function.Call(thisClass.afterEditCell, element, index, columnName);
                }
            }
        });
    };
    this.addNew = function (focusedIndex, focusedColumn) {
        if (thisClass.validate()) {
            var newRow = thisClass.getNewRow();
            newRow.RowIndex = thisClass.LastRowIndex + 1;
            newRow.En_Id = "-" + thisClass.LastRowIndex + 1;
            newRow.IsNew = true;
            newRow.IsChecked = false;
            newRow.IsEmptyRow = true;
            thisClass._dataSource.push(newRow);
            thisClass.LastRowIndex = thisClass.LastRowIndex + 1;
            thisClass.goToLastPage(focusedIndex, focusedColumn);
        }
    };
    this.addByNewRow = function (newRow) {
        if (thisClass.validate()) {            
            newRow.rowIndex = thisClass.LastRowIndex + 1;
            newRow.notChangedIndex = thisClass.LastRowIndex + 1;
            //newRow.En_Id = "-" + thisClass.LastRowIndex + 1;
            newRow.isNew = true;
           // newRow.IsChecked = false;
            newRow.isEmptyRow = true;            
            thisClass._dataSource.push(newRow);
            thisClass.LastRowIndex = thisClass.LastRowIndex + 1;
            thisClass.goToLastPage();
        }
    };
    this.getNewRow = function () {
        var newRow = copy(window["_newRow_" + gridName]);
        newRow.isDeleted = false;
        // newRow.RowIndex = thisClass.LastRowIndex + 1;
        return newRow;
    };
    function copy(mainObj) {
        let objCopy = {}; // objCopy will store a copy of the mainObj
        let key;

        for (key in mainObj) {
            objCopy[key] = mainObj[key]; // copies each property to the objCopy object
        }
        return objCopy;
    }
    this.validate = function () {
        var result = true;
        $.each($("#" + gridName + " input,select"), function (index, element) {
            var originIndex = parseInt($(this).data("index"));
            if (thisClass._dataSource[originIndex] && !thisClass._dataSource[originIndex].isEmptyRow) {
                if ($(element).hasClass("isRequired") && $(element).val() === '') {
                    $(element).closest("td").addClass("error");
                    result = false;
                }
                else if ($(element).closest("td").hasClass("error") && $(element).val() !== '') {
                    $(element).closest("td").removeClass("error");
                }
            }
        
        });
        return result;
    };
    this.save = function (saveUrl,afterSaveCallBack,otherParameterValue,showSuccessMessage) {
       // $('.pleasewait').css('display', 'block');
        var forSaveItemsList = [];
        $.each(thisClass._dataSource, function (index, value) {
            if (!value.isDeleted && (value.isNew || value.isEdited)) {
                forSaveItemsList.push(value);
            }
        });
        if (thisClass.validate() && forSaveItemsList && (!otherParameterValue?forSaveItemsList.length > 0:true)) {
            var saveObj = { model: forSaveItemsList };
            if (otherParameterValue) {
                saveObj = { model: forSaveItemsList, secondParameter: otherParameterValue};
            }        

            Awro.AjaxManager.GeneralRequest(saveUrl, function (data) {
                if (data.success) {
                    if (!(showSuccessMessage && (showSuccessMessage === "doNotShowSuccessMessage"))) {
                        Awro.Notification.Notify("Notify", "Data have been saved successfully", 'success');
                    }
                    thisClass.getGridDataSource();
                    if (afterSaveCallBack) {
                        Awro.Function.Call(afterSaveCallBack);
                    }
                }
                else
                    Awro.Notification.Notify("Error", data.message, 'danger');

            }, saveObj, "", "#" + this.gridName);

        }
        else if (thisClass.validate()) {
            if (afterSaveCallBack) {
                Awro.Function.Call(afterSaveCallBack);
            }          
        }     
    };
    this.saveWithoutConsiderEdited = function (saveUrl, afterSaveCallBack, otherParameterValue, showSuccessMessage) {
       // $('.pleasewait').css('display', 'block');
        var forSaveItemsList = thisClass._dataSource;     
        if (thisClass.validate() && forSaveItemsList && (!otherParameterValue ? forSaveItemsList.length > 0 : true)) {
            var saveObj = { model: forSaveItemsList };
            if (otherParameterValue) {
                saveObj = { model: forSaveItemsList, secondParameter: otherParameterValue };
            }    
            Awro.AjaxManager.GeneralRequest(saveUrl, function (data) {
                if (data.success) {
                    if (!(showSuccessMessage && (showSuccessMessage === "doNotShowSuccessMessage"))) {
                        Awro.Notification.Notify("Notify", "Data have been saved successfully", 'success');
                    }
                    thisClass.getGridDataSource();
                    if (afterSaveCallBack) {
                        Awro.Function.Call(afterSaveCallBack);
                    }
                }
                else
                    Awro.Notification.Notify("Error", data.message, 'danger');

            }, saveObj, "", "#" + this.gridName);

        }
        else if (thisClass.validate()) {
            if (afterSaveCallBack) {
                Awro.Function.Call(afterSaveCallBack);
            }           
        }     
    };
    this.batchDelete = function (deleteUrl) {
        var deletedItems = [];
        $.each(thisClass._dataSource, function (index, row) {
            if (row.IsChecked) {
                deletedItems.push({ Id: row.En_Id, Index: (row.RowIndex - 1), IsNew: row.IsNew });
            }
        });
        if (deletedItems && deletedItems.length > 0) {
            $('#deleteModal').find('#btnDeleteItem').click(function () {
                $('.pleasewait').css('display', 'block');
                var idsList = [];
                $.each(deletedItems, function (subIndex, value) {
                    if (!value.IsNew) {
                        idsList.push(value.Id);
                    }
                    thisClass._dataSource[value.Index].IsDeleted = true;
                });
                if (idsList && idsList.length > 0) {
                    $.post(deleteUrl, { en_Ids: idsList }, function (data) {
                        if (data.success) {
                            showSuccessMessage();
                        }
                        else
                            showFailedMessage(data.Message);
                    }).always(function () {
                        $('#deleteModal').modal('hide');
                        $('.pleasewait').css('display', 'none');
                        thisClass.refreshGrid();
                        $('#deleteModal').find('#btnDeleteItem').unbind('click');
                    });
                }
                else {
                    thisClass.refreshGrid();
                    $('#deleteModal').modal('hide');
                    $('.pleasewait').css('display', 'none');
                    $('#deleteModal').find('#btnDeleteItem').unbind('click');
                }

            });
            $('#deleteModal').modal();

        }

    };
    this.setValue = function (index, columnName, value) {
        if ($("#" + gridName).find("[data-index='" + index + "'][data-column='" + columnName + "']").is('button')) {
            $("#" + gridName).find("[data-index='" + index + "'][data-column='" + columnName + "']").html(value);
        }
        else
            $("#" + gridName).find("[data-index='" + index + "'][data-column='" + columnName + "']").val(value);
    };
    this.bindOnClick = function () {
        $("#" + gridName).find("td").click(function () {
            var index = $(this).parent('tr').data('rowindex');
            if (thisClass.afterCellClick) {
                Awro.Function.Call(thisClass.afterCellClick, this, index);
            }
        });
    };
    this.focusCell = function (index, columnName) {
        $("#" + gridName + " [data-column='" + columnName + "'][data-index='" + index + "']").focus();
    };
    this.bindRowClick = function () {
        $("#" + gridName + " table tr").click(function () {
            $("#" + gridName + " table tr").removeClass("Grid2ActiveRow");
            $(this).addClass("Grid2ActiveRow");
        });
    };
    
}

