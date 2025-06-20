import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DescricaoSuperPoderComponent } from './descricao-super-poder.component';

describe('DescricaoSuperPoderComponent', () => {
  let component: DescricaoSuperPoderComponent;
  let fixture: ComponentFixture<DescricaoSuperPoderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DescricaoSuperPoderComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DescricaoSuperPoderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
