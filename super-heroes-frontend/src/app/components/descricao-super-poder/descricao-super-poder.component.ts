import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { SuperPoder } from '../../models/super-poder';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-descricao-super-poder',
  standalone: true,
  imports: [MatDialogModule, MatButtonModule],
  templateUrl: './descricao-super-poder.component.html',
  styleUrl: './descricao-super-poder.component.scss'
})
export class DescricaoSuperPoderComponent {
  constructor(
    public dialogRef: MatDialogRef<DescricaoSuperPoderComponent>,
    @Inject(MAT_DIALOG_DATA) public data: SuperPoder
  ) {}
}
