var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  console.log("In loadDataTable");
  dataTable = $("#tblData").DataTable({
    ajax: {
      url: "/admin/employeeManage/getall",
    },
    responsive: true,
    columns: [
      { data: "id", width: "10%" },
      {
        // Combine firstName and lastName and display in a single column
        data: null,
        width: "20%",
        render: function (data, type, row) {
          return row.firstName + " " + row.lastName;
        },
      },
      { data: "email", width: "15%" },
      { data: "doj", width: "15%" },
      { data: "designation", width: "15%" },
      { data: "department.name", width: "15%" },
      {
        data: "id",
        render: function (data) {
          return `<div class="w-75 btn-group" role="group">
                    <a href="/admin/employeeManage/upsert?id=${data}" class="btn btn-info mx-2">
                            <i class="bi bi-pencil-square"></i>Edit            
                    </a>
                     <a onClick=Delete('/admin/employeeManage/delete/${data}') class="btn btn-danger mx-2">
                           <i class="bi bi-trash"></i> Delete
                     </a>
                  </div>`;
        },
        width: "15%",
      },
    ],
   
  }).on('error.dt', function (e, settings, techNote, message) {
    console.error('An error occurred: ', message);
});
  console.log("Data table initialized.");
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