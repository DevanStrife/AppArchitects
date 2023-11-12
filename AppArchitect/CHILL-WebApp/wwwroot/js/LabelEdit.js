$(document).ready(function () {
            $(".input-field").hide();

            $(".edit-button").click(function () {
                var itemId = $(this).data("id");
                var parentRow = $(this).closest("tr");
                parentRow.find(".data-text, .input-field").toggle();
                $(this).text("Confirm");
                $(this).removeClass("edit-button").addClass("confirm-button");
            });

            $(".confirm-button").click(function () {
                var itemId = $(this).data("id");
                var parentRow = $(this).closest("tr");
                parentRow.find(".data-text, .input-field").toggle();
                $(this).text("Edit");
                $(this).removeClass("confirm-button").addClass("edit-button");
                parentRow.find(".data-text").each(function () {
                    var fieldName = $(this).closest(".edit-field").data("field");
                    var inputField = parentRow.find(".input-field[name='" + fieldName + "']");
                    $(this).text(inputField.val());
                });
            });
        });