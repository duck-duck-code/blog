import { Entity, Column } from 'typeorm';
import { BaseEntity } from './base.entity';

@Entity()
export class User extends BaseEntity {
  @Column({ type: 'varchar', length: 100 })
  firstName: string;

  @Column({ type: 'varchar', length: 100 })
  lastName: string;

  @Column({ type: 'varchar', length: 150 })
  email: string;

  @Column({ type: 'varchar', length: 50 })
  userName: string;

  @Column({ type: 'varchar', length: 300 })
  bio: string;

  @Column({ type: 'bigint' })
  githubId: string;
}
