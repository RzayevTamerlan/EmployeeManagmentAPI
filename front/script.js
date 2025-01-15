const BASE_URL = "http://localhost:5298/api"

async function getDepartments() {
    // const response = await fetch(`${BASE_URL}/departments`, {
    //     mode: 'no-cors', // Disable CORS
    //     headers: {
    //         'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhNDM3MmY4My1mODc3LTQ0MWMtODA1Ni04MDBmZDI3NjJmMGQiLCJlbWFpbCI6Im1yLmFkbWluQGdtYWlsLmNvbSIsInJvbGUiOiJFbXBsb3llZSIsImp0aSI6IjRlY2Y0OWNhLTNmNjItNDZlMS04ZjY1LTNkODY3ZjJiMTY4OCIsImV4cCI6MTczNjkyODI4MSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1Mjk4LyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTI5OC8ifQ._3AksLWznopddqJivFgyk29HzMf9OGKlfiAp61Q6s9g'
    //     }
    // })
    //     .then((data) => data.json());

    const data = [
        {
          "name": "IT",
          "employees": [],
          "id": "45f7eb7f-4b3c-4bbe-8e76-4c34d4cd9bbf",
          "createdAt": "2025-01-15T04:53:03.752934Z",
          "updatedAt": "2025-01-15T04:53:03.752934Z"
        },
        {
          "name": "HR",
          "employees": [],
          "id": "a88cc6e5-5074-4fe3-93ab-dc280130558e",
          "createdAt": "2025-01-15T04:52:56.169569Z",
          "updatedAt": "2025-01-15T04:52:56.169604Z"
        }
      ];

      renderDepartmentsList(data);
}

function renderDepartmentsList(departments) {
    const departmentList = document.querySelector('.departments_list');
    
    departments.forEach(department => {
        const listItem = document.createElement('li');
        listItem.textContent = department.name;
        
        departmentList.appendChild(listItem);
    });
}


getDepartments();
