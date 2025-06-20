import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditHeroiComponent } from './edit-heroi.component';

describe('EditHeroiComponent', () => {
  let component: EditHeroiComponent;
  let fixture: ComponentFixture<EditHeroiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditHeroiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditHeroiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
