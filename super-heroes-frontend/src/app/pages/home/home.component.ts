import { Component } from '@angular/core';
import { Heroi } from '../../models/heroi';
import { HeroiService } from '../../services/heroi.service';
import { CommonModule } from '@angular/common';
import { EditHeroiComponent } from '../../components/edit-heroi/edit-heroi.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule, MatDialog } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatChipsModule } from '@angular/material/chips';
import { SuperPoder } from '../../models/super-poder';
import { DescricaoSuperPoderComponent } from '../../components/descricao-super-poder/descricao-super-poder.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, MatExpansionModule, MatIconModule, MatButtonModule, MatDialogModule, MatDatepickerModule, MatNativeDateModule, MatChipsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  herois: Heroi[] = [];
  currentHeroi?: Heroi;

  constructor(private heroiService: HeroiService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.heroiService.getAllHerois().subscribe((result: Heroi[]) => (this.herois = result));
  }

  abrirModal(heroi: Heroi) {
    const dialogRef = this.dialog.open(EditHeroiComponent, {
      width: '400px',
      data: { heroi: { ...heroi } } // cria uma cópia para não alterar diretamente
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.ngOnInit(); // Atualiza a lista após salvar/criar
      }
    });
  }

  editHeroi(heroi: Heroi) {
    this.abrirModal(heroi);
  }

  createNewHeroi() {
    this.abrirModal({
      id: 0,
      nome: '',
      nomeHeroi: '',
      superpoderes: [],
      dataNascimento: null,
      altura: 0,
      peso: 0
    });
  }

  removeHeroi(heroi: Heroi) {
    this.heroiService.deleteHeroi(heroi).subscribe(() => {
      this.ngOnInit();
    });
  }

  abrirDescricao(sp: SuperPoder) {
  this.dialog.open(DescricaoSuperPoderComponent, {
    width: '300px',
    data: sp
  });
}
}
