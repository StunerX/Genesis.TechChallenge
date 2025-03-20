import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CdbService } from './cdb.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Genesis.TechChallenge.Frontend';
  
  cdbForm!: FormGroup;
  
  // Resposta que será exibida
  grossAmount: number | null = null;
  netAmount: number | null = null;

  constructor(
    private fb: FormBuilder,
    private cdbService: CdbService
  ) {}

  ngOnInit(): void {
    this.cdbForm = this.fb.group({
      initialAmount: [null],
      period: [null]
    });
  }

  onSubmit(): void {
    const { initialAmount, period } = this.cdbForm.value;

    if (initialAmount != null && period != null) {
      this.cdbService.getCdb(initialAmount, period).subscribe({
        next: (response) => {
          console.log('Resposta da API:', response);

          // Supondo que a API retorne um objeto com finalAmount e finalGrossAmount
          this.grossAmount = response.grossAmount;
          this.netAmount = response.netAmount;
        },
        error: (err) => {
          console.error('Erro ao consultar CDB:', err);
        }
      });
    }
  }
}