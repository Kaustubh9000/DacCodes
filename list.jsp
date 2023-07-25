<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Employees by Dept</title>
</head>
<body>
	<table>
		<thead>
			<th>Id</th>
			<th>First Name</th>
			<th>Last Name</th>
			<th>Email</th>
			<th>Join Date</th>
			<th>Employment Type</th>
			<th>Salary</th>
		</thead>
		<tbody>
			<c:forEach var="emp" items="${requestScope.emp_list}">
				<tr>
					<td>${emp.id}</td>
					<td>${emp.firstName}</td>
					<td>${emp.lastName}</td>
					<td>${emp.email}</td>
					<td>${emp.joinDate}</td>
					<td>${emp.empType}</td>
					<td>${emp.salary}</td>
				</tr>
			</c:forEach>
		</tbody>
		
	</table>
</body>
</html>