var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  console.log("Entered into loaddatatable of department");
  dataTable = $("#DeprtTable").DataTable({
    ajax: {
      url: "/superadmin/departmentManage/getall",
    },
    columns: [
      { data: "id", width: "30%" },
      { data: "name", width: "30%" },
      {
        data: "id",
        render: function (data) {
          return `<div class="w-75 btn-group" role="group">
                          <a href="/superadmin/departmentManage/edit?id=${data}" class="btn btn-info mx-2">
                                  <i class="bi bi-pencil-square"></i>Edit            
                          </a>
                           <a onCLick=Delete('/superadmin/departmentManage/delete/${data}') class="btn btn-danger mx-2">
                                 <i class="bi bi-trash"></i> Delete
                           </a>
                        </div>`;
        },
        width: "15%",
      },
    ],
  });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
      }).then((result) => {
        if (result.isConfirmed) {
          $.ajax({
            url: url,
            type: 'DELETE',
            success: function(data){
                dataTable.ajax.reload();
                toastr.success(data.message);
            }
          })
        }
      });
}
