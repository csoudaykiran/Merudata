import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService} from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private auth: AuthService,private router: Router) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  hideShowPass() {
    this.isText = !this.isText; // Toggle the isText property
    this.eyeIcon = this.isText ? "fa-eye" : "fa-eye-slash";
    this.type = this.isText ? "text" : "password";
  }

  onLogin() {
    if (this.loginForm.valid) {
      // Send the object to the database
      console.log(this.loginForm.value);
      this.auth.login(this.loginForm.value).subscribe({
        next: (res) => {
          alert(res.message);
          this.loginForm.reset(); // Corrected line to reset the form
          this.router.navigate(['dashboard']);
        },
        error: (err) => {
          alert(err?.error.message);
        }
      });
    } else {
      // Throw an error using toaster and highlight required fields
      ValidateForm.validateAllFormFields(this.loginForm);
      alert("Your form is invalid");
    }
  }
}
