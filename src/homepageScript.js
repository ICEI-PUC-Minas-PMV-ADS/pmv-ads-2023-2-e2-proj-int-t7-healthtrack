 if (localStorage.getItem('token') == null) {
    alert('Voce Precisa estar logado para acessar essa página');
    window.location.href = 'Login.html';
}



// Function to save the form data to localStorage
function saveFormData(event) {
    event.preventDefault(); // Prevent form submission
  
    const inputs = this.getElementsByTagName("input");
  
    for (let i = 0; i < inputs.length - 1; i++) {
      const inputId = this.dataset.formIndex + "_" + inputs[i].dataset.inputIndex;
      const inputValue = inputs[i].value;
      localStorage.setItem(inputId, inputValue);
    }
  }
  
  // Function to populate the form fields with saved data
  function populateForm() {
    const forms = document.getElementsByClassName("form-wrapper");
  
    for (let i = 0; i < forms.length; i++) {
      const inputs = forms[i].getElementsByTagName("input");
  
      forms[i].dataset.formIndex = i; // Set form index as a data attribute
  
      for (let j = 0; j < inputs.length - 1; j++) {
        const inputId = i + "_" + j;
        const savedValue = localStorage.getItem(inputId);
        if (savedValue) {
          inputs[j].value = savedValue;
        }
        inputs[j].dataset.inputIndex = j; // Set input index as a data attribute
      }
    }
  }
  
  // Call populateForm() on page load to fill the form fields with saved data
  window.onload = populateForm;
  
  // Add event listener to the forms' submit event to save the form data
  const forms = document.getElementsByClassName("form-wrapper");
  for (let i = 0; i < forms.length; i++) {
    forms[i].addEventListener("submit", saveFormData);
  }

  