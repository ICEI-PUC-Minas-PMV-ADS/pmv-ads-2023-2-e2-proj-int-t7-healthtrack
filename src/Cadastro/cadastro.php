<?php
$servername = "localhost"; // Host do MySQL (geralmente é localhost)
$username = "root"; // Nome de usuário do MySQL
$password = ""; // Senha do MySQL
$database = "HealthTrack"; // Nome do banco de dados

// Conexão com o banco de dados
$conn = new mysqli($servername, $username, $password, $database);

if ($conn->connect_error) {
    die("Falha na conexão com o banco de dados: " . $conn->connect_error);
}

// Obtenha os dados do formulário
$usuario = $_POST['usuario'];
$email = $_POST['email'];
$confirmEmail = $_POST['confirmEmail'];
$senha = $_POST['senha'];
$confirmSenha = $_POST['confirmSenha'];

// Verifique se os campos de senha e e-mail correspondem
if ($email === $confirmEmail && $senha === $confirmSenha) {
    // Consulta SQL para inserir dados na tabela HTKB007D
    $sql = "INSERT INTO HTKB007D (usuario, email, senha) VALUES ('$usuario', '$email', '$senha')";

    if ($conn->query($sql) === true) {
        // Redirecionar para a página "index.html"
        header("Location: index.html");
        exit; // Certifique-se de sair após o redirecionamento para evitar a execução adicional do código.

    } else {
        echo "Erro ao inserir o registro: " . $conn->error;
    }
} else {
    echo "Os campos de e-mail e senha não correspondem.";
}

$conn->close();
?>
