function ManagerCategoryTable() {

    this.tblCategory = 'categoryList';
    this.service = 'Category';
    this.ctrlActions = new ControlActions();
    this.categoryName = "";
    this.columns = "ID,Category Name";

    this.RetrieveAllCategory = function () {
        this.ctrlActions.FillTable(this.service + "/RetrieveAllCategory", this.tblCategory, false);
    }

    this.CreateCategory = function () {
    var categoryInfo = this.ctrlActions.GetDataForm("categoryForm");
    var Category = {CategoryName: categoryInfo.CategoryName}

        this.ctrlActions.PostToAPI(this.service + "/CreateCategory", Category, function (response) { });

        window.location.reload();
    }

    this.Prueba = function (category) {
        categoryName = category.CategoryName;
        console.log(categoryName)
    }

    this.DeleteCategory = function () {
        var Category = { CategoryName: categoryName }
        this.ctrlActions.DeleteToAPI(this.service + "/DeleteCategory", Category, function (response) { });
        window.location.reload();
    }
}

$(document).ready(function () {
    var tblLoad = new ManagerCategoryTable();
    tblLoad.RetrieveAllCategory();
});