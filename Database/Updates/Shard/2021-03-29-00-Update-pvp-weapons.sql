
INSERT INTO biota_properties_float

select b.id, wfloat.type, wfloat.value from biota b 
left outer join biota_properties_float bfloat on bfloat.object_Id = b.id and bfloat.type = 52000
left outer join foredawn_world.weenie_properties_float wfloat on wfloat.type = 52000 and wfloat.object_Id = b.weenie_Class_Id
WHERE b.weenie_Class_Id IN (51965, 51966, 51967, 51968, 51988)
and bfloat.object_id is null
