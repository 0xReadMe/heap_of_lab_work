<!DOCTYPE html>
<html>
<head>
	<title>Студия Детали</title>
	<link rel="shortcut icon" href="images/fa.png" type="image/x-icon">
	<link rel="stylesheet" type="text/css" href="../css/main.css">
</head>
<body>
<?php
	require ("header.php");
?>
	<main>
		<div class="conteiner">
			<div class="h"><h1>Наши проекты</h3></div>
			<table>
				<?php
				require ("connect.php");
				mysqli_set_charset($connect, 'utf8');
				$query='SELECT name, data, FIO, description FROM project INNER JOIN users ON users.ID =project.Author_id';
				$result = mysqli_query($connect, $query);
				foreach ($result as $row) {
					printf("
						<tr>
						<td>
						<p> <span> Название проекта: %s </span> <p>
						<p> <span> Дата создания: </span> %s  <p>
						<p> <span> Автор проекта: </span> %s  <p>
						</td>
						<td> <span> Описание проекта: </span> %s </td>
						</tr>", $row['name'], $row['data'], $row['FIO'], $row['description']);
				}
				?>
			</table>
		</div>
		<div class="solution"></div>
	</main>
<?php
	require("footer.php");
?>