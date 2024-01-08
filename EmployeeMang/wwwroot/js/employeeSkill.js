var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  console.log("Entered into loaddatatable of employeeSkill");
  dataTable = $("#EmpSkillTable").DataTable({
    ajax: {
      url: "/admin/employeeskillmanage/getall",
    },
    columns: [
      { data: "employee.id", width: "10%" },
      {
        // Combine firstName and lastName and display in a single column
        data: null,
        width: "20%",
        render: function (data, type, row) {
          return row.employee.firstName + " " + row.employee.lastName;
        },
      },
      { data: "skill.allSkills", width: "20%" },
      { data: "ratingsInSkill", width: "10%" },
      { data: "experienceInSkill", width: "10%" },
      {
        data: "id",
        render: function (data) {
          return `<div class="w-75 btn-group "  role="group">
                      <a href="/admin/employeeSkillManage/assign?id=${data}" class="btn btn-info mx-2">
                          <i class="bi bi-pencil-square"></i>Assign  
                      </a>          
                    </div>`;
        },
        width: "30%",
      },
    ],
    responsive: true,
  });
}
