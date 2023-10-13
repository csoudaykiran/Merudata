import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService} from 'src/app/services/auth.service';


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  signUpForm!: FormGroup;

  constructor(private fb: FormBuilder, private auth: AuthService,private router: Router) {}

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
       firstName : ['', Validators.required],
       lastName : ['', Validators.required],
       userName : ['', Validators.required],
       email : ['', Validators.required],
       password : ['', Validators.required]
    })
  }

  hideShowPass() {
    this.isText = !this.isText; // Toggle the isText property
    this.eyeIcon = this.isText ? "fa-eye" : "fa-eye-slash";
    this.type = this.isText ? "text" : "password";
  }

  onSignup() {
    if (this.signUpForm.valid) {
      // Perform logic for signup
      console.log(this.signUpForm.value);
  
      this.auth.signUp(this.signUpForm.value).subscribe({
        next: (res => {
          alert(res.message);
          this.signUpForm.reset();
          this.router.navigate(['login']);
        }),
        error: (err) => {
          alert(err?.error.message);
          // Handle errors as needed
        }
      });
      //console.log(this.signUpForm.value)
    } else {
      // Logic for throwing errors
      ValidateForm.validateAllFormFields(this.signUpForm);
    }
  }
}
