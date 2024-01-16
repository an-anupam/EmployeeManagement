var dataTable;

$(document).ready(function () {
  loadDataTable();
});

function loadDataTable() {
  console.log("Entered into loaddatatable of employeeSkill");
  dataTable = $("#HomeTable").DataTable({
    ajax: {
      url: "/user/home/getall",
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
      {
        // Combine firstName and lastName and display in a single column
        data: null,
        width: "20%",
        render: function (data, type, row) {
          return row.employee.email;
        },
      },
      {
        data: function (row) {
          return row.employeeSkills && row.employeeSkills.length > 0
            ? row.employeeSkills
                .map((skill) => (skill.skill ? skill.skill.allSkills : ""))
                .join(", ")
            : "";
        },
        width: "20%",
      },

      {
        // Combine firstName and lastName and display in a single column
        data: null,
        width: "20%",
        render: function (data, type, row) {
          return row.employee.department.name;
        },
      },
      {
        // Combine firstName and lastName and display in a single column
        data: null,
        width: "20%",
        render: function (data, type, row) {
          return row.employee.designation;
        },
      },
      {
        data: "employee.id",
        render: function (data) {
          return `<div class="w-75 btn-group "  role="group">
                      <a href="/user/home/view?id=${data}" class="btn btn-info mx-2">
                     <i class="bi bi-eye"></i>View 
                     </a>         
                    </div>`;
        },
        width: "30%",
      },
    ],
    dom: "Bfrtip",
    buttons: [
      {
        extend: "excel",
        text: "Export to Excel",
        className: " btn-info bi bi-file-text",
        exportOptions: {
          columns: ":visible",
        },
      },
      {
        extend: "pdf",
        text: "Export to PDF",
        className: "btn-danger bi bi-file-pdf",
        exportOptions: {
          columns: ":visible",
        },
      },
    ],
    // responsive: true,
  });
}

// var dataTable;

// $(document).ready(function () {
//   loadDataTable();
// });

// function loadDataTable() {
//   console.log("Entered into loaddatatable of employeeSkill");
//   dataTable = $("#EmpSkillTable").DataTable({
//     ajax: {
//       url: "/admin/employeeSkillManage/getall",
//     },
//     columns: [
//       { data: "employee.id", width: "10%" },
//       {
//         // Combine firstName and lastName and display in a single column
//         data: null,
//         width: "20%",
//         render: function (data, type, row) {
//           return row.employee.firstName + " " + row.employee.lastName;
//         },
//       },
//       {
//         data: null,
//         width: "20%",
//         render: function (data, type, row) {
//           // Combine all skill names from the employeeSkills list
//           var allSkills = row.employeeSkills.map(skill => skill.skill.allSkills).join(", ");
//           return allSkills;
//         },
//       },
//       { data: "ratingsInSkill", width: "10%" },
//       { data: "experienceInSkill", width: "10%" },
//       {
//         data: "id",
//         render: function (data) {
//           return `<div class="w-75 btn-group "  role="group">
//                       <a href="/admin/employeeSkillManage/assign?id=${data}" class="btn btn-info mx-2">
//                           <i class="bi bi-pencil-square"></i>Assign
//                       </a>
//                     </div>`;
//         },
//         width: "30%",
//       },
//     ],
//     responsive: true,
//   });
// }
