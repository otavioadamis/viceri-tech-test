import { Component, Inject } from '@angular/core';
import { Heroi } from '../../models/heroi';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HeroiService } from '../../services/heroi.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { SuperPoder } from '../../models/super-poder';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { HeroiSaveDTO } from '../../models/heroi-save-dto';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-edit-heroi',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatButtonModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  templateUrl: './edit-heroi.component.html',
  styleUrl: './edit-heroi.component.scss'
})
export class EditHeroiComponent {
  heroi: Heroi;
  superPoderesDisponiveis: SuperPoder[] = [];
  erro: string | null = null;

  constructor(
    private heroiService: HeroiService,
    private dialogRef: MatDialogRef<EditHeroiComponent>,
    private snackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: { heroi: Heroi }) {
    this.heroi = data.heroi;
  }

  ngOnInit(): void {
    this.heroiService.getAllSuperpoderes().subscribe(poderes => {
      this.superPoderesDisponiveis = poderes;
    })
  }

  criar(heroi: Heroi) {
    const dto = this.mapearParaDTO(heroi);

    this.heroiService.createHeroi(dto).subscribe({
      next: () => {
        this.mostrarMensagemSucesso('Herói criado com sucesso!');
        this.dialogRef.close(true); // fecha modal e indica atualização
      },
      error: (err) => {
        if (err.status === 400) {
          this.erro = err.error.Message;
        }
      }
    });
  }

  salvar(heroi: Heroi) {
    const dto = this.mapearParaDTO(heroi);

    this.heroiService.updateHeroi(heroi.id, dto).subscribe({
      next: () => {
        this.mostrarMensagemSucesso('Herói atualizado com sucesso!');
        this.dialogRef.close(true);
      },
      error: (err) => {
        if (err.status === 400) {
          this.erro = err.error.Message;
        }
      }
    });
  }

  cancelar() {
    this.dialogRef.close(false); // fechar modal sem alterações
  }

  private mapearParaDTO(heroi: Heroi): HeroiSaveDTO {
    return {
      nome: heroi.nome,
      nomeHeroi: heroi.nomeHeroi,
      dataNascimento: this.formatarData(heroi.dataNascimento),
      altura: heroi.altura,
      peso: heroi.peso,
      superpoderesIds: heroi.superpoderes.map(sp => sp.id),
    };
  }

  private formatarData(data: Date | null): string {
    if (!data) {
      throw new Error('Data de nascimento é obrigatória.');
    }

    return data.toISOString().split('T')[0];
  }

  mostrarMensagemSucesso(mensagem: string) {
    this.snackBar.open(mensagem, 'OK', {
      duration: 3000,
      horizontalPosition: 'center',
      verticalPosition: 'bottom',
    });
  }
}
