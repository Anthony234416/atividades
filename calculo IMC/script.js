document.getElementById("formularioIMC").addEventListener("submit", function (e) {
    e.preventDefault();
  
    const nome = document.getElementById("nome").value;
    const sexo = document.getElementById("sexo").value;
    const peso = parseFloat(document.getElementById("peso").value);
    const altura = parseFloat(document.getElementById("altura").value);
  
    const imc = peso / (altura * altura);
    const condicao = classificarCondicao(imc, sexo);
    const meta = calcularMetaPeso(imc, sexo, peso, altura);
  
    const resultado = `
      <p><strong>Nome:</strong> ${nome}</p>
      <p><strong>Sexo:</strong> ${sexo === "F" ? "Feminino" : "Masculino"}</p>
      <p><strong>Peso:</strong> ${peso} kg</p>
      <p><strong>Altura:</strong> ${altura} m</p>
      <p><strong>IMC:</strong> ${imc.toFixed(2)}</p>
      <p><strong>Condição:</strong> ${condicao}</p>
      <p><strong>Ajuste:</strong> ${meta}</p>
    `;
  
    document.getElementById("resultado").innerHTML = resultado;
  });
  
  function classificarCondicao(imc, sexo) {
    if (sexo === "F") {
      if (imc < 19.1) return "Abaixo do peso";
      else if (imc <= 25.8) return "Peso normal";
      else if (imc <= 27.3) return "Marginalmente acima do peso";
      else if (imc <= 32.3) return "Acima do peso ideal";
      else return "Obesa";
    } else if (sexo === "M") {
      if (imc < 20.7) return "Abaixo do peso";
      else if (imc <= 26.4) return "Peso normal";
      else if (imc <= 27.8) return "Marginalmente acima do peso";
      else if (imc <= 31.1) return "Acima do peso ideal";
      else return "Obeso";
    } else {
      return "Sexo inválido";
    }
  }
  
  function calcularMetaPeso(imc, sexo, peso, altura) {
    let imcMin, imcMax;
  
    if (sexo === "F") {
      imcMin = 19.1;
      imcMax = 25.8;
    } else if (sexo === "M") {
      imcMin = 20.7;
      imcMax = 26.4;
    } else {
      return "Sexo inválido";
    }
  
    const pesoMin = imcMin * altura * altura;
    const pesoMax = imcMax * altura * altura;
  
    if (peso < pesoMin) {
      const ganho = pesoMin - peso;
      return `Deve GANHAR aproximadamente ${ganho.toFixed(2)} kg para atingir o peso normal.`;
    } else if (peso > pesoMax) {
      const perda = peso - pesoMax;
      return `Deve PERDER aproximadamente ${perda.toFixed(2)} kg para atingir o peso normal.`;
    } else {
      return "Peso dentro da faixa normal. Nenhum ajuste necessário.";
    }
  }
  